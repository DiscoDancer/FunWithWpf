using System;
using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace DataLibrary
{
    public static class OrderCRUD
    {
        public class ValueType
        {
            public bool IsString { get; set; }
            public string Value { get; set; }
        }

        private static readonly string SqlConnect = ConnectionStringsService.Resolve();

        public static List<OrderExtended> GetAll()
        {
            using (var connection = new SqlConnection(SqlConnect))
            {

                return connection.Query<OrderExtended>("Select Orders.OrderID, Customers.CustomerID, Employees.EmployeeID, Products.ProductID, CONCAT(Customers.LastName, + space(1) + Customers.MiddleName, + space(1) + Customers.FirstName) as CustomerName," +
                    " CONCAT(Employees.LastName, + space(1) + Employees.MiddleName, + space(1) + Employees.FirstName) as EmployeeName, Products.Name as ProductName," +
                    " Orders.Quantity, Orders.Price, Orders.OrderDate from Orders left join Customers on Orders.CustomerID = Customers.CustomerID" +
                    " left join Employees on Orders.EmployeeID = Employees.EmployeeID left join Products on Orders.ProductID = Products.ProductID")
                    .ToList();
            }
        }

        public static void AddOrder(Order order)
        {
            var queryDictionary = new Dictionary<string, ValueType>();
            var props = order.GetType().GetProperties().Where(x => !x.Name.Contains("ID"));
            foreach (var prop in props)
            {
                var val = prop.GetValue(order, null);
                var valToString = val?.ToString();
                if (valToString?.Length > 0)
                {
                    queryDictionary.Add(prop.Name, new ValueType
                    {
                        IsString = prop.PropertyType == typeof(string) || prop.PropertyType == typeof(DateTime),
                        Value = valToString
                    });
                }
            }

            var names = "(" + queryDictionary.Keys.Aggregate((x, y) => x + "," + y) + ")";
            var values = queryDictionary.Values
                .Select(x => x.IsString ? $"'{x.Value}'" : x.Value)
                .Aggregate((x, y) => x + "," + y);
            values = $"({values})";
            var query = $"INSERT INTO Orders{names} VALUES{values};";

            //using (var connection = new SqlConnection(SqlConnect))
            //{

            //    connection.Query(query);
            //}
        }

        public static void UpdateOrder(Order order)
        {
            var queryDictionary = new Dictionary<string, ValueType>();

            var props = order.GetType().GetProperties().Where(x => !x.Name.Contains("ID"));
            foreach (var prop in props)
            {
                var val = prop.GetValue(order, null);
                var valToString = val?.ToString();
                if (valToString?.Length > 0)
                {
                    queryDictionary.Add(prop.Name, new ValueType
                    {
                        IsString = prop.PropertyType == typeof(string) || prop.PropertyType == typeof(DateTime),
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
                $"UPDATE Orders SET {mergedPairs} WHERE OrderID = {order.OrderID}";

            //using (var connection = new SqlConnection(SqlConnect))
            //{
            //    connection.Query(query);
            //}
        }

        public static void DeleteOrder(OrderExtended order)
        {
            using (var connection = new SqlConnection(SqlConnect))
            {
                connection.Query($"delete from Orders where OrderID = {order.OrderID}");
            }
        }
    }
}
