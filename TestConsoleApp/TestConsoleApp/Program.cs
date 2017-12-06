using System;
using System.Text;
using DataLibrary;

namespace TestConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var crud = new CustomerCRUD();
            var customers = crud.GetAll();
            foreach (Customers customer in customers)
            {
                Console.OutputEncoding = Encoding.UTF8;

                Console.WriteLine("FirstName:" + customer.FirstName);
                Console.WriteLine("MiddleName:" + customer.MiddleName);
                Console.WriteLine("LastName:" + customer.LastName);
                Console.WriteLine("City: " + customer.City);
                Console.WriteLine("Address: " + customer.Address);
                Console.WriteLine("Phone:" + customer.Phone + "\n");
            }
            Console.ReadLine();
        }
    }
}

