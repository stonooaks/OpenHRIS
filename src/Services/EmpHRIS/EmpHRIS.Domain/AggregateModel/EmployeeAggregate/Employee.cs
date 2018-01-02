using empHRIS.Domain.Exceptions;
using empHRIS.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmpHRIS.Domain.AggregateModel.EmployeeAggregate
{

    /// <summary>
    /// Employee Aggregate Root
    /// </summary>
    public class Employee : EntityData, IAggregateRoot
    {

        #region constructors
        public Employee(string empId, string firstName, string middleName, string lastName, string nationalId,
                        DateTime birthDate, DateTime serviceDate, string address1, string address2, string city,
                        string state, string country, string zipCode, Gender gender, EEOCodes eeoCode)
        {
            EmpId = empId;
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            NationalId = nationalId;
            BirthDate = birthDate;
            ServiceDate = serviceDate;
            EmpGender = gender;
            EmpEeocode = eeoCode;
            _personAddresses.Add(new Address(address1, address2, city, state, zipCode, country, true, Id));

        }

        protected Employee()
        {
            _personAddresses = new List<Address>();
            _employment = new List<Employment>();
            _status = new List<EmpStatus>();
        } 
        #endregion

        #region private variables
        private readonly List<Address> _personAddresses;
        private int _genderId;
        private int _eeoCodeId; 
        #endregion

        #region public properties
        public string EmpId { get; private set; }
        public DateTime ServiceDate { get; private set; }
        public string FirstName { get; private set; }
        public string MiddleName { get; private set; }
        public string LastName { get; private set; }
        public string NationalId { get; private set; }
        public DateTime BirthDate { get; private set; }
        public Gender EmpGender { get; private set; }
        public EEOCodes EmpEeocode { get; private set; }
        public IReadOnlyCollection<Address> PersonAddresses => _personAddresses;
        #endregion

        #region public methods
        /// <summary>
        /// Add address to Employee
        /// </summary>
        /// <param name="streetAddress1"></param>
        /// <param name="streetAddress2"></param>
        /// <param name="city"></param>
        /// <param name="state"></param>
        /// <param name="zipCode"></param>
        /// <param name="country"></param>
        /// <param name="isHome"></param>
        public void AddAddress(string streetAddress1, string streetAddress2, string city, string state,
                            string zipCode, string country, bool isHome)
        {
            var existingAddress = _personAddresses
                .Where(a => a.StreetAddress1 == streetAddress1)
                .Where(a => a.StreetAddress2 == streetAddress2)
                .Where(a => a.City == city)
                .Where(a => a.State == state)
                .Where(a => a.ZipCode == zipCode)
                .SingleOrDefault();

            if (existingAddress != null)
            {
                throw new EmployeeDomainException("Address already exist for this employee");
            }
            else
            {
                var address = new Address(streetAddress1, streetAddress2, city, state, zipCode, country, false);
                _personAddresses.Add(address);
                if (isHome)
                {
                    SetHomeAddress(address);
                }
            }
        }

        /// <summary>
        /// Set Home Address
        /// </summary>
        /// <param name="isHome"></param>
        public void SetHomeAddress(Address address)
        {
            if (!_personAddresses.Any(a => a.Id == address.Id))
            {

                throw new EmployeeDomainException("Address does not belong to this employee");

            }
            else
            {

                if (_personAddresses.Where(a => a.IsHome == true).ToList().Count != 0)
                {
                    foreach (var addr in _personAddresses)
                    {
                        addr.SetOtherAddress();
                    }
                }

                address.SetHomeAddress();
            }
        }

        /// <summary>
        /// Set Gender
        /// </summary>
        /// <param name="id"></param>
        public void SetGender(int id)
        {
            _genderId = id;
        }

        /// <summary>
        /// Set EEOCode
        /// </summary>
        /// <param name="id"></param>
        public void SetEEOCode(int id)
        {
            _eeoCodeId = id;
        } 
        #endregion
    }

    /// <summary>
    /// Gender Enumeration
    /// </summary>
    public class Gender : Enumeration
    {
        public static Gender Female = new Gender(1, nameof(Female).ToLowerInvariant());
        public static Gender Male = new Gender(2, nameof(Male).ToLowerInvariant());
        public static Gender Unspecified = new Gender(3, nameof(Unspecified).ToLowerInvariant());


        protected Gender() { }

        public Gender(int id, string name) : base(id, name)
        {

        }

        public static IEnumerable<Gender> List() =>
            new[] { Female, Male, Unspecified };

        public static Gender FromName(string name)
        {
            var gender = List().SingleOrDefault(g => String.Equals(g.Name, name, StringComparison.CurrentCultureIgnoreCase));

            if (gender == null)
            {
                throw new EmployeeDomainException($"Possible gender values: {String.Join(",", List().Select(g => g.Name))}");
            }

            return gender;
        }

        public static Gender From(int id)
        {
            var gender = List().SingleOrDefault(g => g.Id == id);

            if (gender == null)
            {
                throw new EmployeeDomainException($"Possible gender values: {String.Join(",", List().Select(g => g.Name))}");
            }

            return gender;
        }
    }

    /// <summary>
    /// EEO Codes Enumeration
    /// </summary>
    public class EEOCodes : Enumeration
    {
        public static EEOCodes HispanicOrLatino = new EEOCodes(1, nameof(HispanicOrLatino).ToLowerInvariant());
        public static EEOCodes WhiteNotHispanic = new EEOCodes(2, nameof(WhiteNotHispanic).ToLowerInvariant());
        public static EEOCodes BlackNotHispanic = new EEOCodes(3, nameof(BlackNotHispanic).ToLowerInvariant());
        public static EEOCodes AsianNotHispanic = new EEOCodes(4, nameof(AsianNotHispanic).ToLowerInvariant());
        public static EEOCodes PacificNotHispanic = new EEOCodes(5, nameof(PacificNotHispanic).ToLowerInvariant());
        public static EEOCodes AmericanIndian = new EEOCodes(6, nameof(AmericanIndian).ToLowerInvariant());
        public static EEOCodes MultiRaceNotHispanic = new EEOCodes(7, nameof(MultiRaceNotHispanic).ToLowerInvariant());


        protected EEOCodes() { }

        public EEOCodes(int id, string name) : base(id, name) { }

        public static IEnumerable<EEOCodes> List() =>
            new[] { HispanicOrLatino, WhiteNotHispanic, BlackNotHispanic, AsianNotHispanic, PacificNotHispanic, AmericanIndian, MultiRaceNotHispanic };

        public static EEOCodes FromName(string name)
        {
            var eeoCodes = List().SingleOrDefault(g => String.Equals(g.Name, name, StringComparison.CurrentCultureIgnoreCase));

            if (eeoCodes == null)
            {
                throw new EmployeeDomainException($"Possible gender values: {String.Join(",", List().Select(g => g.Name))}");
            }

            return eeoCodes;
        }

        public static EEOCodes From(int id)
        {
            var eeoCodes = List().SingleOrDefault(g => g.Id == id);

            if (eeoCodes == null)
            {
                throw new EmployeeDomainException($"Possible gender values: {String.Join(",", List().Select(g => g.Name))}");
            }

            return eeoCodes;
        }
    }
}
