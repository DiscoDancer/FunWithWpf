using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace DataLibrary
{
    public static class OrderCRUD
    {
        private const string sqlConnect = "Data Source=DESKTOP-37BI6K1;Initial Catalog=InternetShop;User ID=Kreal;Password=2137";
        public static List<Order> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(sqlConnect))
            {

                return connection.Query<Order>("select * from Orders").ToList();
            }
        }
    }
}
