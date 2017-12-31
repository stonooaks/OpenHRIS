using empHRIS.empHRIS.Domain.SeedWork;
using System.Threading.Tasks;

namespace EmpHRIS.Domain.AggregateModel.AssignmentAggregate
{
    public interface IAssignmentRepository : IRepository<Assignment>
    {
        Assignment Add(Assignment distribution);
        Assignment Update(Assignment distribution);
        Task<Assignment> FindAsync(int Id);
    }
}
