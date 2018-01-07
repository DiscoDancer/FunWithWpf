using DataLibrary.Models.Entities;

namespace DataLibrary.Services.Repository
{
    public class OrderRepository: SQLServerRepository<Order>
    {
        protected override string TableName => "Orders";
    }
}
