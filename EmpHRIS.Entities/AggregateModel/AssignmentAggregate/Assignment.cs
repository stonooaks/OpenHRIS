using empHRIS.Domain.SeedWork;
using EmpHRIS.Domain.AggregateModel.EmployeeAggregate;
using EmpHRIS.Domain.AggregateModel.EmploymentAggregate;
using EmpHRIS.Domain.AggregateModel.PositionAggregate;
using EmpHRIS.Domain.AggregateModel.StatusAggregate;
using EmpHRIS.Domain.AggregateModel.AccountAggregate;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EmpHRIS.Domain.AggregateModel.AssignmentAggregate
{




    public class Assignment : EntityData, IAggregateRoot
    {
        public Employee Employee { get; set; }
        public Position Position { get; set; }
        public Employment Employment { get; set; }
        public EmpStatus EmpStatus { get; set; }
        public DateTime Eff_date { get; set; }
        public DateTime End_date { get; set; }
        public OvertimeStatus OverTimeStatus { get; set; }
        public SalaryChange SalaryChange { get; set; }
        public WorkPeriod WorkPeriod { get; set; }
        public CostCenter HomeCostCenter { get; set; }
        public double AnnualSalary { get; set; }
        public double HourlyRate { get; set; }
        public double PeriodSalary { get; set; }
        public Account account { get; set; }
        public FundSource fundSource { get; set; }
        public double distSalary { get; set; }
        public double distPercent { get; set; }
        public double fteSplit { get; set; }



    }

    public class FundSource : EntityData
    {
        public string code { get; set; }
    }

    public class WorkPeriod : EntityData
    {
        public string Code { get; set; }
    }

    public class SalaryChange : EntityData
    {
        public string Code { get; set; }
    }

    public class OvertimeStatus : EntityData
    {
        public string Code { get; set; }
    }
}

    
