using System;

namespace DataLibrary
{
    public  class Order
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public DateTime OrderDate { get; set; }

        public override string ToString()
        {
            var output = "";

            output += $"OrderID:{OrderID}\n";
            output += $"CustomerID:{CustomerID}\n";
            output += $"EmployeeID:{EmployeeID}\n";
            output += $"ProductID:{ProductID}\n";
            output += $"Quantity:{Quantity}\n";
            output += $"Price:{Price}\n";
            output += $"OrderDate:{OrderDate}\n";

            return output;
        }
    }
}
