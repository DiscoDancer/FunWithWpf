using System;
using DataLibrary.Attributes;

namespace DataLibrary.Models.Entities
{
    public class Product
    {
        [PrimaryKey]
        public int ProductID { get; set; }
        [ForeignKey]
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }

        public static implicit operator Product(global::WpfApp.ProductCategory v)
        {
            throw new NotImplementedException();
        }
    }
}
