using EmpHRIS.Interfaces;
using EmpHRIS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpHRIS.Repository
{
    public class PersonRepository : IPersonRepository
    {

        private readonly EmployeeContext _context;
        public PersonRepository(EmployeeContext context)
        {
            _context = context;
        }

        public void Add(Person TEntity)
        {
            _context.Add(TEntity);
        }

        public void Delete(Person Entity)
        {
            _context.Remove(Entity);
        }

        public bool Exists(object id)
        {
            return _context.Person.Any(p => p.Id == (int) id);
        }

        public Person Find(object id)
        {
            return _context.Person.Where(p => p.Id == (int)id).SingleOrDefault();
        }

        public IEnumerable<Person> List()
        {
            return _context.Person.ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public Task SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public void Update(Person Entity)
        {
            _context.Entry(Entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
