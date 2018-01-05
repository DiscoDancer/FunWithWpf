using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace DataLibrary
{
    public static class OrderCRUD
    {
        private static readonly string SqlConnect = ConnectionStringsService.Resolve();

        public static List<Order> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(SqlConnect))
            {

                return connection.Query<Order>("Select Orders.OrderID, Customers.CustomerID, Employees.EmployeeID, Products.ProductID, CONCAT(Customers.LastName, + space(1) + Customers.MiddleName, + space(1) + Customers.FirstName) as CustomerName," +
                    " CONCAT(Employees.LastName, + space(1) + Employees.MiddleName, + space(1) + Employees.FirstName) as EmployeeName, Products.Name as ProductName," +
                    " Orders.Quantity, Orders.Price, Orders.OrderDate from Orders left join Customers on Orders.CustomerID = Customers.CustomerID" +
                    " left join Employees on Orders.EmployeeID = Employees.EmployeeID left join Products on Orders.ProductID = Products.ProductID")
                    .ToList();
            }
        }
        public static void DeleteOrder(Order order)
        {
            using (var connection = new SqlConnection(SqlConnect))
            {
                connection.Query($"delete from Orders where OrderID = {order.OrderID}");
            }
        }
    }
}
