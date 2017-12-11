using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace DataLibrary
{
    public static class EmployeeCRUD
    {
        private const string sqlConnect = "Data Source=LAPTOP-VLEV;Initial Catalog=Wpf;User ID=sa;Password=Passw0rd";
        public static List<Employee> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(sqlConnect))
            {

                return connection.Query<Employee>("select * from Employees").ToList();
            }
        }
    }
}
