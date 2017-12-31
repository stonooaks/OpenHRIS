using empHRIS.Domain.SeedWork;
using System.Threading.Tasks;

namespace EmpHRIS.Domain.AggregateModel.EmployeeAggregate
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Employee Add(Employee employee);
        Employee Update(Employee employee);
        Task<Employee> FindAsync(string empId);
    }
}
