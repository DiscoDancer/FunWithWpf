using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace DataLibrary
{
    public static class CustomerCRUD
    {
        //private const string sqlConnect = "Data Source=DESKTOP-37BI6K1;Initial Catalog=InternetShop;User ID=Kreal;Password=2137";
        private const string sqlConnect = "Data Source=LAPTOP-VLEV;Initial Catalog=Wpf;User ID=sa;Password=Passw0rd";

        public static List<Customer> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(sqlConnect))
            {

                return connection.Query<Customer>("select * from Customers").ToList();
            }
        }
    }
}
