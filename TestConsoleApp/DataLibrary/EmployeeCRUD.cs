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

        public static void AddEmployee(Employee employee)
        {
            var queryDictionary = new Dictionary<string, string>();
            var props = employee.GetType().GetProperties().Where(x => !x.Name.Contains("ID"));
            foreach (var prop in props)
            {
                var val = prop.GetValue(employee, null);
                var valToString = val?.ToString();
                if (valToString?.Length > 0)
                {
                    queryDictionary.Add(prop.Name, val.ToString());
                }
            }

            var names = "(" + queryDictionary.Keys.Aggregate((x, y) => x + "," + y) + ")";
            var values = queryDictionary.Values
                .Select(x => $"'{x}'")
                .Aggregate((x, y) => x + "," + y);
            values = $"({values})";
            var query = $"INSERT INTO Employees{names} VALUES{values};";

            using (var connection = new SqlConnection(SqlConnect))
            {

                connection.Query(query);
            }
        }
        public static void DeleteEmployee(Employee employee)
        {
            using (var connection = new SqlConnection(SqlConnect))
            {

                connection.Query($"delete from Employees where EmployeeID = {employee.EmployeeID}");
            }
        }
    }
}
