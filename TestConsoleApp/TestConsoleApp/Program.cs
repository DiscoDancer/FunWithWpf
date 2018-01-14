using DataLibrary.Models.Entities;
using DataLibrary.Services.Repository;

namespace TestConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var customer = new Customer
            {
                Address = "RRR"
            };

            UnitOfWork.Customers.Add(customer);
        }
    }
}

