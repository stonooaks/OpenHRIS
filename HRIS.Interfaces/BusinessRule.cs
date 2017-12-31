using System;
using System.Collections.Generic;
using System.Text;

namespace HRIS.Common
{
    public class BusinessRule
    {
        private string _ruleDescripion;

        public BusinessRule(string ruleDescription)
        {
            _ruleDescripion = ruleDescription;
        }

        public String RuleDescription
        {
            get
            {
                return _ruleDescripion;
            }
        }
    }
}
