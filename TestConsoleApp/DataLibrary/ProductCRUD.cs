using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary
{
    public static class ProductCRUD
    {
        private const string sqlConnect = "Data Source=DESKTOP-37BI6K1;Initial Catalog=InternetShop;User ID=Kreal;Password=2137";
        public static List<Product> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(sqlConnect))
            {

                return connection.Query<Product>("select * from Products").ToList();
            }
        }
    }
}
