using System;
using System.ComponentModel.DataAnnotations;



namespace EmpHRIS.ViewModels
{
    public class EmployeeViewModel
    {

        [EmpId(ErrorMessage = "{0} is not a valid Employee Id")]
        public string EmpId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string NationalId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime ServiceDate { get; set; }
    }
}
