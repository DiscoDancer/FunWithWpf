using DataLibrary.Models.Entities;
namespace DataLibrary.Services.Repository
{
    class ProductCategoryRepository : SQLServerRepository<ProductCategory>
    {
        protected override string TableName => "ProductCategory";
    }
}
