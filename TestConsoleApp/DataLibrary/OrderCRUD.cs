using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace DataLibrary
{
    public static class OrderCRUD
    {
        private static readonly string SqlConnect = ConnectionStringsService.Resolve();

        public static List<Order> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(SqlConnect))
            {

                return connection.Query<Order>("select * from Orders").ToList();
            }
        }
        public static void DeleteOrder(Order order)
        {
            using (var connection = new SqlConnection(SqlConnect))
            {

                connection.Query($"delete from Orders where OrderID = {order.OrderID}");
            }
        }
    }
}
