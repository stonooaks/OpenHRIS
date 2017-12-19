using EmpHRIS.Interfaces;
using EmpHRIS.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using HRIS.Interfaces;
using System.Threading.Tasks;

namespace EmpHRIS.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private readonly EmployeeContext _context;
        public EmployeeRepository(EmployeeContext dbContext)
        {
            _context = dbContext;
        }

        public IEnumerable<Employee> List()
        {
            return _context.Employees.ToList();
        }

        public Employee Find(object id)
        {
            return _context.Employees.Find((int) id);
        }

        public void Add(Employee TEntity)
        {
            _context.Add(TEntity);
        }

        public void Update(Employee Entity)
        {
            _context.Entry<Employee>(Entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void Delete(Employee Entity)
        {
            _context.Remove(Entity);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
              
        public Task SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public bool Exists(object id)
        {
            return _context.Employees.Any(e => e.Id == (int) id);
        }

        
    }
}
