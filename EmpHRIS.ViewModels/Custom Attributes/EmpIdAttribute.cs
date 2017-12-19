using System;
using System.ComponentModel.DataAnnotations;

namespace EmpHRIS.ViewModels
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    sealed class EmpIdAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {

            var emp_id = (String)value;
            return MatchesMask(emp_id);
        }

        internal bool MatchesMask(string emp_id)
        {
            if(emp_id.Length != 9)
            {
                return false;
            }

            if (emp_id.StartsWith("9"))
            {
                return false;
            }

            return true;
        }
    }
}
