using EmpHRIS.Interfaces;
using EmpHRIS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpHRIS.Repository
{
    public class CityRepository : ICityRepository
    {

        private readonly EmployeeContext _context;
        public CityRepository(EmployeeContext dbContext)
        {
            _context = dbContext;
        }

        public void Add(City TEntity)
        {
            _context.Add(TEntity);
        }

        public void Delete(City Entity)
        {
            _context.Remove(Entity);
        }

        public City Find(object id)
        {
            return _context.City.Find((int)id);
        }

        public IEnumerable<City> List()
        {
            return _context.City.ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public Task SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public void Update(City Entity)
        {
            _context.Update(Entity);
        }

        public bool Exists(object id)
        {
            return _context.City.Any(c => c.Id == (int)id);
        }

        public City FindbyZipcode(string ZipCode)
        {
            return _context.City.Where(z => z.ZipCode == ZipCode).SingleOrDefault();
        }

        public City FindByName(string Name)    
        {
            return _context.City.Where(c => c.CityName == Name).SingleOrDefault();
        }
    }
}
