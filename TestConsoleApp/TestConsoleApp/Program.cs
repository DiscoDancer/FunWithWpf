using System;
using System.Text;
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
                MiddleName = "C",
                City = "Кемерово"
            };

            var q = CustomerCRUD.UpdateCustomer(customer);
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine(q);

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
            Console.ReadKey();
        }
    }
}

