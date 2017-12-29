using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace DataLibrary
{
    public static class CustomerCRUD
    {
        private static readonly string SqlConnect = ConnectionStringsService.Resolve();

        public static List<Customer> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(SqlConnect))
            {

                return connection.Query<Customer>("select * from Customers").ToList();
            }
        }

        public static string UpdateCustomer(Customer customer)
        {

            return "UPDATE Customers SET FirstName = 'Василий', MiddleName = 'Васильевич', LastName = 'Васильев', Address = 'Ленинградский 30/4', City = 'Новосибирск', Phone = '89235151238' WHERE CustomerID = 1073";
        }

        public static void AddCustomer(Customer customer)
        {
            var queryDictionary = new Dictionary<string, string>();
            var props = customer.GetType().GetProperties().Where(x => !x.Name.Contains("ID"));
            foreach (var prop in props)
            {
                var val = prop.GetValue(customer, null);
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
            var query = $"INSERT INTO Customers{names} VALUES{values};";

            using (var connection = new SqlConnection(SqlConnect))
            {

                connection.Query(query);
            }
        }

        public static void DeleteCustomer(Customer customer)
        {
            using (var connection = new SqlConnection(SqlConnect))
            {

                connection.Query($"delete from Customers where CustomerID = {customer.CustomerID}");
            }
        }
    }
}
