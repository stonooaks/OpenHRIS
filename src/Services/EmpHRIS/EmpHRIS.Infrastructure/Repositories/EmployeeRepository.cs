using empHRIS.Domain.SeedWork;
using EmpHRIS.Domain.AggregateModel.EmployeeAggregate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmpHRIS.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeContext _context;

        public IUnitOfWork UnitOfWork{ get { return _context; }}
        
        public EmployeeRepository(EmployeeContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Add employee
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public Employee Add(Employee employee)
        {
            return _context.Employees.Add(employee).Entity;
        }

        /// <summary>
        /// Find Employee
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Employee> FindAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if(employee != null)
            {
                await _context.Entry(employee).Collection(e => e.PersonAddresses).LoadAsync();
                await _context.Entry(employee).Reference(e => e.EmpGender).LoadAsync();
                await _context.Entry(employee).Reference(e => e.EmpEeocode).LoadAsync();
            }

            return employee;

        }


        public void Update(Employee employee)
        {
            _context.Entry(employee).State = EntityState.Modified;
        }
    }
}
