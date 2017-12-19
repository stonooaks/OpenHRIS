using System;
using System.ComponentModel.DataAnnotations;


namespace EmpHRIS.ViewModels
{
    public class EmployeeViewModel
    {
        public string empId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        
        public string NationalId { get; set; }
    }
}
