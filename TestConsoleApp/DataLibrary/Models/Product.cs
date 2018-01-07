using DataLibrary.Attributes;

namespace DataLibrary.Models
{
    public class Product
    {
        [PrimaryKey]
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
    }
}
