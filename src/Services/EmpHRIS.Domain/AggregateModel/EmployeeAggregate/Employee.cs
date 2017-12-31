using empHRIS.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace EmpHRIS.Domain.AggregateModel.EmployeeAggregate
{
    public class Employee : EntityData, IAggregateRoot
    {

        protected Employee()
        {
            _personAddresses = new List<Address>();
        }

        private List<Address> _personAddresses;

        public string empId { get; set; }
        public List<Code> Codes { get; set; }
        public DateTime ServiceDate { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public List<Address> PersonAddresses { get; set; }
        public string NationalId { get; set; }
        public DateTime BirthDate { get; set; }

    }

    public class Address : EntityData
    {

        public string StreetAddress1 { get; private set; }
        public string StreetAddress2 { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string ZipCode { get; private set; }
        public string Country { get; private set; }
        public bool IsHome { get; private set; }


    }

    public class CodeHeader : EntityData
    {
        public string CodeHead { get; set; }
    }

    public class Code : EntityData
    {
        public CodeHeader CodeHeader { get; set; }
        public string Detail { get; set; }
    }
}
