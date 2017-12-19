using EmpHRIS.Interfaces;
using EmpHRIS.Models;
using EmpHRIS.Repository;
using Microsoft.EntityFrameworkCore;
using System;

namespace EmpHRIS.Services
{
    public class EmployeeService
    {

        private readonly IEmployeeRepository _empRepo;
        private readonly ICityRepository _cityRepo;
        private readonly IAddressRepository _addrRepo;
        public EmployeeService(IEmployeeRepository empRepo, ICityRepository cityRepo, IAddressRepository addrRepo)
        {
            _empRepo = empRepo;
            _cityRepo = cityRepo;
            _addrRepo = addrRepo;

        }

        /// <summary>
        /// Adds a employees address
        /// </summary>
        /// <param name="PersonId"></param>
        /// <param name="StreetAddress1"></param>
        /// <param name="StreetAddress2"></param>
        /// <param name="ZipCode"></param>
        /// <returns>Address</returns>
        public void AddAddress(int PersonId, string StreetAddress1, string StreetAddress2, string ZipCode)
        {          
            Address NewAddress = new Address()
            {

                StreetAddress1 = StreetAddress1,
                StreetAddress2 = StreetAddress2,
                City = _cityRepo.FindbyZipcode(ZipCode),
                PersonId = PersonId
            };

            _addrRepo.Add(NewAddress);
            _addrRepo.SaveChanges();
        }

        
    }
}
