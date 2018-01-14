using DataLibrary.Models.Entities;

namespace DataLibrary.Models
{
    public  class ExtendedOrder: Order
    {
        public string CustomerName { get; set; }
        public string EmployeeName { get; set; }
        public string ProductName { get; set; }
        public string ProductCategory { get; set; }
    }
}
