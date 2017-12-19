using EmpHRIS.Interfaces;
using EmpHRIS.Models;
using EmpHRIS.Repository;
using Microsoft.EntityFrameworkCore;
using System;

namespace EmpHRIS.Services
    {
        public class PersonService
        {

            private readonly IPersonRepository _personRepo;
            
            public PersonService(IPersonRepository personRepo)
            {
                _personRepo = personRepo;
            }

            public Person AddPerson(string _firstName, string _middleName, string _lastName,
                                    string _nationalId, DateTime _birthDate, _streetAddress
            {
                return new Person()
                {
                    FirstName = _firstName,
                    MiddleName = _middleName,
                    LastName = _lastName,
                    NationalId = _nationalId,
                    BirthDate = __birthDate,
                    Addresses = 
                    
                }
            }
        }
    }

}
}
