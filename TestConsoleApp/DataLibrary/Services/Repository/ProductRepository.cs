using DataLibrary.Models.Entities;

namespace DataLibrary.Services.Repository
{
    public class ProductRepository: SQLServerRepository<Product>
    {
        protected override string TableName => "Products";
    }
}
