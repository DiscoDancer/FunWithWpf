using System;
using DataLibrary.Attributes;

namespace DataLibrary.Models.Entities
{
    public class Order
    {
        [PrimaryKey]
        public int OrderID { get; set; }
        [ForeignKey]
        public int CustomerID { get; set; }
        [ForeignKey]
        public int EmployeeID { get; set; }
        [ForeignKey]
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
    }
}
