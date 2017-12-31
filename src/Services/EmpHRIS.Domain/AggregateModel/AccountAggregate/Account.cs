using empHRIS.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmpHRIS.Domain.AggregateModel.AccountAggregate
{
    public class Account : EntityData, IAggregateRoot
    {
        public string AccountNumber { get; set; }
        public CostCenter CostCenter { get; set; }
        public Entity Entity { get; set; }
        public Project Project { get; set; }
        public Reporting Reporting { get; set; }
    }

    public class Reporting : EntityData
    {
        public string Code { get; set; }
    }

    public class Project : EntityData
    {
        public string Code { get; set; }
        public string Year { get; set; }
    }

    public class Entity : EntityData
    {
        public string Code { get; set; }
    }

    public class CostCenter : EntityData
    {
        public string Code { get; set; }
    }
}
