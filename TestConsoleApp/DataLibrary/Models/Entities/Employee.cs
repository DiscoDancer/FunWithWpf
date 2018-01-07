using DataLibrary.Attributes;

namespace DataLibrary.Models.Entities
{
    public class Employee
    {
        [PrimaryKey]
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public int Salary { get; set; }
        public int PriorSalary { get; set; }
        public string Phone { get; set; }
    }
}
