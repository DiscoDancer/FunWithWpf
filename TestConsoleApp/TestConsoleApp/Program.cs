using System;
using DataLibrary;

namespace TestConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var customer = new Customer
            {
                LastName = "A",
                FirstName = "B",
                MiddleName = "C"
            };

            var q = CustomerCRUD.UpdateCustomer(customer);

            // CustomerCRUD


            //Console.WriteLine(Environment.UserName);

            //var customers = CustomerCRUD.GetAll();

            //CustomerCRUD.AddCustomer(new Customer
            //{
            //    LastName = "A",
            //    FirstName = "B",
            //    MiddleName = "C"
            //});

            //customers = CustomerCRUD.GetAll();
            //Console.ReadKey();
        }
    }
}

