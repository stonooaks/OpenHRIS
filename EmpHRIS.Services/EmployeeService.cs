using EmpHRIS.Interfaces;
using EmpHRIS.Entities;
using EmpHRIS.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using EmpHRIS.ViewModels;

namespace EmpHRIS.Services
{
    public class EmployeeService
    {

        private readonly IEmployeeRepository _empRepo;
        private readonly ICityRepository _cityRepo;
        private readonly IAddressRepository _addrRepo;
        private readonly IPersonRepository _personRepo;
        public EmployeeService(IEmployeeRepository empRepo, ICityRepository cityRepo, IAddressRepository addrRepo, IPersonRepository personRepo)
        {
            _empRepo = empRepo;
            _cityRepo = cityRepo;
            _addrRepo = addrRepo;
            _personRepo = personRepo;

        }

        public void AddEmployee(EmployeeViewModel employee)
        {
            Person p = createPerson(employee);
            _personRepo.Add(p);
            _addrRepo.Add(createAddress(employee, p.Id, true));
            _empRepo.Add(createEmployee(employee, p.Id));
            _empRepo.SaveChanges();


        }

        #region Private Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="personId"></param>
        /// <param name="IsHome"></param>
        /// <returns></returns>
        private Address createAddress(EmployeeViewModel employee, int personId, bool IsHome) {
            return new Address()
            {
                StreetAddress1 = employee.Address1,
                StreetAddress2 = employee.Address2,
                City = _cityRepo.FindbyZipcode(employee.ZipCode),
                PersonId = personId,
                IsHome = IsHome
            };
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        private Person createPerson(EmployeeViewModel employee) {


            return new Person()
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                MiddleName = employee.MiddleName,
                NationalId = employee.NationalId,
                BirthDate = employee.BirthDate
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="personId"></param>
        /// <returns></returns>
        private Employee createEmployee(EmployeeViewModel employee, int personId)
        {
            return new Employee()
            {
                empId = employee.empId,
                Person = _personRepo.Find(personId),
                ServiceDate = employee.ServiceDate
            };
        }
        #endregion

    }







}
