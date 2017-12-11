using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace DataLibrary
{
    public static class EmployeeCRUD
    {
        private const string sqlConnect = "Data Source=DESKTOP-37BI6K1;Initial Catalog=InternetShop;User ID=Kreal;Password=2137";
        public static List<Employee> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(sqlConnect))
            {

                return connection.Query<Employee>("select * from Employees").ToList();
            }
        }
    }
}
