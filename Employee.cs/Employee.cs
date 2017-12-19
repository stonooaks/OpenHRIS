using System;
using System.Collections.Generic;

namespace EmpHRIS.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string empId { get; set; }
        public List<CodeHeader> Codes { get; set; }
        public DateTime ServiceDate { get; set; }
        public Person Person { get; set; }
    }

    public class CodeHeader
    {
        public int Id { get; set; }
        public string Code { get; set; }
    }

    public class CodeDetail
    {
        public int Id { get; set; }
        public CodeHeader Code { get; set; }
        public string Detail { get; set; }
    }

}
