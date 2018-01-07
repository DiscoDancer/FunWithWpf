using DataLibrary.Models.Entities;

namespace DataLibrary.Services.Repository
{
    public class CustomerRepository: SQLServerRepository<Customer>
    {
        protected override string TableName => "Customers";
    }
}
