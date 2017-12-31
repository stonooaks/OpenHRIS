using empHRIS.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmpHRIS.Domain.AggregateModel.EmploymentAggregate
{
    public class Employment : EntityData, IAggregateRoot
    {
        public string Code { get; set; }

    }
}

