using EmpHRIS.Interfaces;
using EmpHRIS.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace EmpHRIS.Repository
{
    public class AddressRepository : IAddressRepository
    {
        private readonly EmployeeContext _context;
        public AddressRepository(EmployeeContext context)
        {
            _context = context;
        }

        public void Add(Address TEntity)
        {
            _context.Add(TEntity);
        }

        public IEnumerable<Address> List()
        {
            return _context.Address.ToList();
        }

        public void Delete(Address Entity)
        {
            _context.Remove(Entity);
        }

        public Address Find(object id)
        {
            return _context.Address.Where(a => a.Id == (int) id).SingleOrDefault();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public Task SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public void Update(Address Entity)
        {
            _context.Entry(Entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public bool Exists(object id)
        {
            return _context.Address.Any(a => a.Id == (int) id);
        }

        public bool IsHomeAddress(object id)
        {
            return _context.Address.Any(a => a.Id == (int)id && a.IsHome);
        }

    }
}
