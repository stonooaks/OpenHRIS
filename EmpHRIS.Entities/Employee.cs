using HRIS.Interfaces;
using System;
using System.Collections.Generic;

namespace EmpHRIS.Entities
{
    public class Employee : EntityData
    {
        public string empId { get; set; }
        public virtual List<CodeHeader> Codes { get; set; }
        public DateTime ServiceDate { get; set; }
        public Person Person { get; set; }
    }

    public class CodeHeader : EntityData
    {
        public string Code { get; set; }
    }

    public class CodeDetail : EntityData
    {
        public CodeHeader Code { get; set; }
        public string Detail { get; set; }
    }

}
