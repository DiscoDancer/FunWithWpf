using DataLibrary.Attributes;

namespace DataLibrary.Models.Entities
{
   public class ProductCategory
    {
        [PrimaryKey]
        public int CategoryID { get; set; }
        public string Name { get; set; }
    }
}
