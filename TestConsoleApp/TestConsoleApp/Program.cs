using DataLibrary.Models.Entities;
using DataLibrary.Services.Repository;

namespace TestConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var x = UnitOfWork.Products.GetAll();

            var customer = new Customer
            {
                CustomerID = 1,
                FirstName = "VLADIK"
            };

            UnitOfWork.Customers.Delete(customer);
        }
    }
}

