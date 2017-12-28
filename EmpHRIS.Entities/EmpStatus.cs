using HRIS.Interfaces;

namespace EmpHRIS.Entities
{
    public class EmpStatus : EntityData
    {
        public StatusCode statusCode { get; set; }
    }

    public enum StatusCode
    {
        Active , Inactive, Terminated
    }
}