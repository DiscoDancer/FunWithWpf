using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace DataLibrary
{
    public static class EmployeeCRUD
    {
        public class ValueType
        {
            public bool IsString { get; set; }
            public string Value { get; set; }
        }

        private static readonly string SqlConnect = ConnectionStringsService.Resolve();

        public static List<Employee> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(SqlConnect))
            {

                return connection.Query<Employee>("select * from Employees").ToList();
            }
        }

        public static void UpdateEmployee(Employee employee)
        {
            
                var queryDictionary = new Dictionary<string, ValueType>();

                var props = employee.GetType().GetProperties().Where(x => !x.Name.Contains("ID"));
                foreach (var prop in props)
                {
                    var val = prop.GetValue(employee, null);
                    var valToString = val?.ToString();
                    if (valToString?.Length > 0)
                    {
                        queryDictionary.Add(prop.Name, new ValueType
                        {
                            IsString = prop.PropertyType == typeof(string),
                            Value = valToString
                        });
                    }
                }

                var pairs = new List<string>();

                foreach (var p in queryDictionary)
                {
                    pairs.Add(p.Key + " = " + (p.Value.IsString ? $"'{p.Value.Value}'" : p.Value.Value));
                }

                var mergedPairs = pairs.Aggregate((x, y) => $" {x}, {y} ");

                var query =
                    $"UPDATE Employees SET {mergedPairs} WHERE EmployeeID = {employee.EmployeeID}";

                using (var connection = new SqlConnection(SqlConnect))
                {
                    connection.Query(query);
                }
            }

            public static void AddEmployee(Employee employee)
            {
                var queryDictionary = new Dictionary<string, ValueType>();
                var props = employee.GetType().GetProperties().Where(x => !x.Name.Contains("ID"));
                foreach (var prop in props)
                {
                    var val = prop.GetValue(employee, null);
                    var valToString = val?.ToString();
                    if (valToString?.Length > 0)
                    {
                        queryDictionary.Add(prop.Name, new ValueType
                        {
                            IsString = prop.PropertyType == typeof(string),
                            Value = valToString
                        });
                    }
                }

                var names = "(" + queryDictionary.Keys.Aggregate((x, y) => x + "," + y) + ")";
                var values = queryDictionary.Values
                    .Select(x => x.IsString ? $"'{x.Value}'" : x.Value)
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
