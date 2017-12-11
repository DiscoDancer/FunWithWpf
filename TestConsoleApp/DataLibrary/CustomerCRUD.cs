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
    }
}
