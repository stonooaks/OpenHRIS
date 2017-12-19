using System;
using System.Collections.Generic;

namespace Person.Interfaces
{
    public interface IPerson
    {
        int Id { get; set; }
        string FirstName { get; set; }
        string MiddleName { get; set; }
        string LastName { get; set; }
        List<IAddress> Addresses { get; set; }
        string NationalId { get; set; }
        DateTime BirthDate { get; set; }
        

    }

    public interface ICity
    {
        int Id { get; set; }
        string CityName { get; set; }
        string ZipCode { get; set; }
        IState State { get; set; }
    }

    public interface IState
    {
        int Id { get; set; }
        string StateName { get; set; }
    }

    public interface IAddress
    {
        int Id { get; set; }
        int PersonId { get; set; }
        string StreetAddress1 { get; set; }
        string StreetAddress2 { get; set; }
        ICity City { get; set; }
    }
}
