using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace DataLibrary
{
    public static class CustomerCRUD
    {
        private static readonly string SqlConnect = ConnectionStringsService.Resolve();

        public static List<Customer> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(SqlConnect))
            {

                return connection.Query<Customer>("select * from Customers").ToList();
            }
        }

        //public static List<Customer> AddCustomers()
        //{
        //    using (SqlConnection connection = new SqlConnection(SqlConnect))
        //    {

        //        return connection.Query<Customer>("insert into Customers (CustomerID,FirstName,MiddleName,LastName,Address,City,Phone) values(11,'Pupkin','Vasiliy','Vasil`evich','Oktyabrskiy,84','Kemerovo',89039514782);").ToList();
        //    }
        //}

        //public static void DeleteCustomers()
        //{
            
        //}
    }
}
