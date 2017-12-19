using EmpHRIS.Entities;
using HRIS.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmpHRIS.Interfaces
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        
    }

    public interface ICityRepository : IRepository<City>
    {
        City FindbyZipcode(string ZipCode);
        City FindByName(string Name);
    }

    public interface IAddressRepository : IRepository<Address>
    {
        bool IsHomeAddress(object id);
    }

    public interface IStateRepository : IRepository<State>
    {
        State FindByAbbr(string Abbr);
    }
}
