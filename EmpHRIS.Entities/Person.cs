﻿using HRIS.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmpHRIS.Entities
{
    public class Person : EntityData
    {       
       
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public virtual List<Address> Addresses { get; set; }
        public string NationalId { get; set; }
        public DateTime BirthDate { get; set; }
    }

    public class Address : EntityData
    {
               
        public string StreetAddress1 { get; set; }
        public string StreetAddress2 { get; set; }
        public City City { get; set; }
        public int PersonId { get; set; }
        public bool IsHome { get; set; }
    }

    public class City : EntityData
    {
               
        public string CityName { get; set; }
        public string ZipCode { get; set; }
        public State State { get; set; }
    }

    public class State : EntityData
    {
        
        public string StateName { get; set; }
        public string Abbr { get; set; }
    }


}
