﻿using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace DataLibrary
{
    public static class CustomerCRUD
    {
        public class ValueType
        {
            public bool IsString { get; set; }
            public string Value { get; set; }
        }

        private static readonly string SqlConnect = ConnectionStringsService.Resolve();

        public static List<Customer> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(SqlConnect))
            {
                return connection.Query<Customer>("select * from Customers").ToList();
            }
        }

        public static void UpdateCustomer(Customer customer)
        {
            var queryDictionary = new Dictionary<string, ValueType>();

            var props = customer.GetType().GetProperties().Where(x => !x.Name.Contains("ID"));
            foreach (var prop in props)
            {
                var val = prop.GetValue(customer, null);
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
                $"UPDATE Customers SET {mergedPairs} WHERE CustomerID = {customer.CustomerID}";

            using (var connection = new SqlConnection(SqlConnect))
            {
                connection.Query(query);
            }
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
