using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace DataLibrary
{
    public static class ProductCRUD
    {
        public class ValueType
        {
            public bool IsString { get; set; }
            public string Value { get; set; }
        }

        private static readonly string SqlConnect = ConnectionStringsService.Resolve();

        public static List<Product> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(SqlConnect))
            {

                return connection.Query<Product>("select * from Products").ToList();
            }
        }

        public static string UpdateProduct(Product product)
        {
            {
                var queryDictionary = new Dictionary<string, ValueType>();

                var props = product.GetType().GetProperties().Where(x => !x.Name.Contains("ID"));
                foreach (var prop in props)
                {
                    var val = prop.GetValue(product, null);
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
                var query =
                    $"UPDATE Products SET{names} VALUES{values} WHERE ProductID = {product.ProductID}";
                return query;
            }
        }

        public static void AddProduct(Product product)
        {
            var queryDictionary = new Dictionary<string, string>();
            var props = product.GetType().GetProperties().Where(x => !x.Name.Contains("ID"));
            foreach (var prop in props)
            {
                var val = prop.GetValue(product, null);
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
            var query = $"INSERT INTO Products{names} VALUES{values};";

            using (var connection = new SqlConnection(SqlConnect))
            {

                connection.Query(query);
            }
        }

        public static void DeleteProduct(Product product)
        {
            using (var connection = new SqlConnection(SqlConnect))
            {

                connection.Query($"delete from Products where ProductID = {product.ProductID}");
            }
        }
    }
}
