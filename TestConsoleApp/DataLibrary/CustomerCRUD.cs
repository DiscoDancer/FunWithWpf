using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace DataLibrary
{
    public class CustomerCRUD
    {
        public List<Customers> GetAll()
        {
            using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-37BI6K1;Initial Catalog=InternetShop;User ID=Kreal;Password=2137"))
            {

                return connection.Query<Customers>("select * from Customers").ToList();
            }
        }
    }
}
