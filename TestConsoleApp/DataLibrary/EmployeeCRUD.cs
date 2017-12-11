using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace DataLibrary
{
    public static class EmployeeCRUD
    {
        private static readonly string SqlConnect = ConnectionStringsService.Resolve();

        public static List<Employee> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(SqlConnect))
            {

                return connection.Query<Employee>("select * from Employees").ToList();
            }
        }
    }
}
