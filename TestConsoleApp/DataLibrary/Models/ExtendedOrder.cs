using DataLibrary.Models.Entities;

namespace DataLibrary.Models
{
    public  class OrderExtended: Order
    {
        public string CustomerName { get; set; }
        public string EmployeeName { get; set; }
        public string ProductName { get; set; }
    }
}
