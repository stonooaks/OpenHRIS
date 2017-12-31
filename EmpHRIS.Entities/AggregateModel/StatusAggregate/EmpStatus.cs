using empHRIS.Domain.SeedWork;

namespace EmpHRIS.Domain.AggregateModel.StatusAggregate
{
    public class EmpStatus : EntityData, IAggregateRoot
    {
        public StatusCode statusCode { get; set; }
    }

    public enum StatusCode
    {
        Active , Inactive, Terminated
    }
}