using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace MongoWebAppTest.Models
{
    public class EmployeeViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        [DisplayName("Joining Date")]
        public DateTime JoiningDate { get; set; }
        [DisplayName("Resignation Date")]
        public DateTime ResignationDate { get; set; }
        [DisplayName("Is Male?")]
        public bool IsMale { get; set; }
        public AddressViewModel Address { get; set; }
        public decimal Salary { get; set; }
        public int Age { get; set; }
        public List<DepartmentViewModel> Departments { get; set; }
    }
}
