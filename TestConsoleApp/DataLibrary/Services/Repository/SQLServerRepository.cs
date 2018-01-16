using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using DataLibrary.Attributes;

namespace DataLibrary.Services.Repository
{
    public abstract class SQLServerRepository<T>: IRepository<T> where T: class 
    {
        protected abstract string TableName { get; }

        private readonly string SqlConnect = ConnectionStringsService.Resolve();

        public virtual void Add(T entity)
        {
            var queryDictionary = GetPropertiesValues(entity);

            var names = "(" + queryDictionary.Keys.Aggregate((x, y) => x + "," + y) + ")";
            var values = queryDictionary.Values
                .Select(x => x.IsQuoted ? $"'{x.Value}'" : x.Value)
                .Aggregate((x, y) => x + "," + y);
            values = $"({values})";
            var query = $"INSERT INTO {TableName} {names} VALUES {values};";

            using (var connection = new SqlConnection(SqlConnect))
            {

                connection.Query(query);
            }
        }

        public virtual void Update(T entity)
        {
            var queryDictionary = GetPropertiesValues(entity);

            var pairs = new List<string>();

            foreach (var p in queryDictionary)
            {
                pairs.Add(p.Key + " = " + (p.Value.IsQuoted ? $"'{p.Value.Value}'" : p.Value.Value));
            }

            var mergedPairs = pairs.Aggregate((x, y) => $" {x}, {y} ");
            var pk = GetPK(entity);

            var query =
                $"UPDATE {TableName} SET {mergedPairs} WHERE {pk.Item1} = {pk.Item2}";

            using (var connection = new SqlConnection(SqlConnect))
            {
                connection.Query(query);
            }
        }

        public virtual void Delete(T entity)
        {
            var pk = GetPK(entity);

            var query = $"delete from {TableName} where {pk.Item1} = {pk.Item2}";

            using (var connection = new SqlConnection(SqlConnect))
            {

                connection.Query(query);
            }
        }

        public virtual List<T> GetAll()
        {
            using (var connection = new SqlConnection(SqlConnect))
            {

                return connection.Query<T>($"select * from {TableName}").ToList();
            }
        }

        private (string, string) GetPK(T entity)
        {
            var pkAttr = entity.GetType().GetProperties()
                .First(prop => Attribute.IsDefined(prop, typeof(PrimaryKey)));
            var pkName = pkAttr.Name;
            var pkValue = pkAttr.GetValue(entity, null).ToString();

            return (pkName, pkValue);
        }

        private Dictionary<string, Models.IsQuotedValue> GetPropertiesValues(T entity)
        {
            var queryDictionary = new Dictionary<string, Models.IsQuotedValue>();
            var props = entity.GetType().GetProperties().Where(x => !Attribute.IsDefined(x, typeof(PrimaryKey)));

            foreach (var prop in props)
            {
                var val = prop.GetValue(entity, null);
                if (val == null)
                {
                    continue;
                }

                var valToString = prop.PropertyType == typeof(DateTime) ?
                    Convert.ToDateTime(val).ToString("yyyy-MM-dd HH:mm:ss.fff")
                    : val.ToString();
                if (valToString.Length > 0)
                {
                    queryDictionary.Add(prop.Name, new Models.IsQuotedValue
                    {
                        IsQuoted = prop.PropertyType == typeof(string) || prop.PropertyType == typeof(DateTime),
                        Value = valToString
                    });
                }
            }

            return queryDictionary;
        }
    }
}
