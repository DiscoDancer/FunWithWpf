using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace TestConsoleApp
{
    public class Program
    {

        static void Main(string[] args)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-37BI6K1;Initial Catalog=InternetShop;User ID=Kreal;Password=2137"))
            {

                var customers =
                     connection.Query<Customers>("select * from Customers").ToList();
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
            }
            Console.ReadLine();
        }
    }
}

