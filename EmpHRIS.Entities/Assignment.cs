using HRIS.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EmpHRIS.Entities
{

    public class Distribution : EntityData
    {
        public Assignment Assignment { get; set; }
        public Account account { get; set; }
        public FundSource fundSource { get; set; }

        [DataType(DataType.Currency)]
        public double distSalary { get; set; }

        public double distPercent { get; set; }
        public double fteSplit { get; set; }
    }

    public class FundSource : EntityData
    {
        public string code { get; set; }
    }

    public class Assignment : EntityData
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
        public Unit HomeCostCenter { get; set; }

        [DataType(DataType.Currency)]
        public double AnnualSalary { get; set; }
        
        [DataType(DataType.Currency)]
        public double HourlyRate { get; set; }

        [DataType(DataType.Currency)]
        public double PeriodSalary { get; set; }


        
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

    public class Employment : EntityData
    {
        public string Code { get; set; }
        
    }
}
