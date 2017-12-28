using HRIS.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EmpHRIS.Entities
{
    public class Position : EntityData
    {
        public PosClass posClass { get; set; }
        public DateTime effDate { get; set; }
        public string fteNumber { get; set; }
    }

    public class PosClass : EntityData
    {
        public CensusCode censusCode { get; set; }
        public WorkComp workComp { get; set; }
        public SalaryStruct salaryStruct { get; set; }
        public SHACode shaCode { get; set; }
        public string code { get; set; }
        public string subclass { get; set; }
        public DateTime effDate { get; set; }
        
    }

  
    public class SHACode : EntityData
    {
        public string code { get; set; }
    }

    public class WorkComp : EntityData
    {
        public string code { get; set; }
    }

    public class CensusCode : EntityData
    {
        public string code { get; set; }
    }

    public class SalaryStruct : EntityData
    {
        public PayGrade payGrade {get;set;}
        public string code { get; set; }
       

    }

    public class PayGrade : EntityData
    {
        public string code { get; set; }

        [DataType(DataType.Currency)]
        public double minAmount { get; set; }

        [DataType(DataType.Currency)]
        public double midAmount { get; set; }

        [DataType(DataType.Currency)]
        public double maxAmount { get; set; }
    }
}
