namespace DataLibrary
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public int Salary { get; set; }
        public int PriorSalary { get; set; }
        public string Phone { get; set; }

        public override string ToString()
        {
            var output = "";

            output += $"FirstName:{FirstName}\n";
            output += $"MiddleName:{MiddleName}\n";
            output += $"LastName:{LastName}\n";
            output += $"Position:{Position}\n";
            output += $"Salary:{Salary}\n";
            output += $"PriorSalary:{PriorSalary}\n";
            output += $"Phone:{Phone}\n";

            return output;
        }
    }
}
