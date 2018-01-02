using empHRIS.Domain.Exceptions;
using empHRIS.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmpHRIS.Domain.AggregateModel.EmployeeAggregate
{
    /// <summary>
    /// Address Object Class
    /// </summary>
    public class Address : EntityData
    {
        #region private variables
        private int _empId;
        private string _streetAddress1;
        private string _streetAddress2;
        private string _city;
        private string _state;
        private string _zipCode;
        private string _country;
        private bool _isHome = false;
        #endregion

        #region public properties
        public string StreetAddress1 { get; private set; }
        public string StreetAddress2 { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string ZipCode { get; private set; }
        public string Country { get; private set; }
        public bool IsHome { get; private set; }
        #endregion

        #region constructors
        protected Address() { }

        public Address(string streetAddress1, string streetAddress2, string city, string state,
                        string zipCode, string country, bool isHome, int empId)
        {

            if (String.IsNullOrWhiteSpace(streetAddress1))
            {
                throw new EmployeeDomainException("StreetAddress1 cannot be empty");
            }
            if (String.IsNullOrWhiteSpace(city))
            {
                throw new EmployeeDomainException("City cannot be empty");
            }
            if (String.IsNullOrWhiteSpace(state))
            {
                throw new EmployeeDomainException("State cannot be empty");
            }
            if (String.IsNullOrWhiteSpace(zipCode))
            {
                throw new EmployeeDomainException("ZipCode cannot be empty");
            }
            if (String.IsNullOrWhiteSpace(country))
            {
                throw new EmployeeDomainException("County cannot be empty");
            }

            _empId = empId;
            _streetAddress1 = streetAddress1;
            _streetAddress2 = streetAddress2;
            _city = city;
            _state = state;
            _zipCode = zipCode;
            _country = country;
            _isHome = isHome;
        }
        #endregion

        #region public methods
        /// <summary>
        /// Get address by id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Address Find(int Id)
        {
            return new Address(_streetAddress1, _streetAddress2, _city,
                _state, _zipCode, _country, _isHome, _empId);
        }

        public string GetStreetAddress(int Id)
        {
            return @"{_streetAddress1} {_streetAddress2}";
        }

        /// <summary>
        /// return all addresses for employee
        /// </summary>
        /// <param name="empId"></param>
        /// <returns></returns>
        public IEnumerable<Address> getAllAddress(int empId)
        {
            return new List<Address>().Where(a => a._empId == empId).ToList();
        }

        /// <summary>
        /// set the HomeAddress true
        /// </summary>
        public void SetHomeAddress()
        {
            _isHome = true;
        }

        /// <summary>
        /// Set the HomeAddress false
        /// </summary>
        public void SetOtherAddress()
        {
            _isHome = false;
        }
        #endregion
    }
}

   