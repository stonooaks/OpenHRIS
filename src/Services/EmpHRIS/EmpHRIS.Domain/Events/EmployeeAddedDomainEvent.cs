using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmpHRIS.Domain.Events
{
    public class EmployeeAddedDomainEvent : INotification
    {
        public string EmployeeId { get; private set; }
        public string EmployeeName { get; private set; }
        public DateTime ServiceDate { get; private set; }
        
        public EmployeeAddedDomainEvent(string employeeId, string employeeName, 
            DateTime serviceDate)
        {
            EmployeeId = employeeId;
            EmployeeName = employeeName;
            ServiceDate = serviceDate;
        }
    }
}
