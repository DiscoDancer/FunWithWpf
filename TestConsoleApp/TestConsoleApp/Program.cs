using System;
using System.Text;
using DataLibrary;

namespace TestConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            //var crud = new CustomerCRUD();
            var customers = CustomerCRUD.GetAll();
            foreach (Customer customer in customers)
            {
                Console.OutputEncoding = Encoding.UTF8;

                string x = customer.ToString();

                Console.WriteLine(x);
            }
            Console.ReadLine();
        }
    }
}

