namespace DataLibrary
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }

        public override string ToString()
        {
            var output = "";

            output += $"FirstName:{FirstName}\n";
            output += $"MiddleName:{MiddleName}\n";
            output += $"LastName:{LastName}\n";
            output += $"Address:{Address}\n";
            output += $"City:{City}\n";
            output += $"Phone:{Phone}\n";

            return output;
        }
    }
}
