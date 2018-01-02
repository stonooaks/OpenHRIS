using empHRIS.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmpHRIS.Domain.AggregateModel.EmployeeAggregate
{
    public class EmploymentType : ValueObject {
        public string Code { get; private set; }
        public string Description { get; private set; }

        protected EmploymentType() { }

        /// <summary>
        /// public Constructor
        /// </summary>
        /// <param name="code"></param>
        /// <param name="description"></param>
        public EmploymentType(string code, string description)
        {
            Code = code;
            Description = description;
        }
   
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Code;
            yield return Description;
        }
    }
}

