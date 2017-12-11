using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace DataLibrary
{
    public static class ProductCRUD
    {
        private static readonly string SqlConnect = ConnectionStringsService.Resolve();

        public static List<Product> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(SqlConnect))
            {

                return connection.Query<Product>("select * from Products").ToList();
            }
        }
    }
}
