using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using DataLibrary.Models;
using DataLibrary.Models.Entities;

namespace DataLibrary.Services.Repository
{
    public static class UnitOfWork
    {
        public static IRepository<Customer> Customers { get; } = new CustomerRepository();
        public static IRepository<Employee> Employees { get; } = new EmployeeRepository();
        public static IRepository<Product> Products { get; } = new ProductRepository();
        public static IRepository<ProductCategory> ProductCategories { get; } = new ProductCategoryRepository();
        public static IRepository<Order> Orders { get; } = new OrderRepository();

        private static readonly string SqlConnect = ConnectionStringsService.Resolve();

        public static List<ExtendedProduct> GetAllExtendedProducts()
        {
            using (var connection = new SqlConnection(SqlConnect))
            {
                return connection.Query<ExtendedProduct>(
                    " Select Products.ProductID, Products.CategoryID, Products.Name, Products.Color, Products.Description," +
                    " ProductCategories.Name as CategoryName" +
                    " From Products" +
                    " Inner Join ProductCategories" +
                    " On Products.CategoryID = ProductCategories.CategoryID"
                ).ToList();
            }
        }

        public static List<ExtendedOrder> GetAllExtendedOrders()
        {
            using (var connection = new SqlConnection(SqlConnect))
            {
                return connection.Query<ExtendedOrder>(
                    " Select" +
                    " Orders.OrderID, Orders.Quantity, Orders.Price, Orders.OrderDate," +
                    " Customers.CustomerID, CONCAT(Customers.LastName, + space(1) + Customers.FirstName, + space(1) + Customers.MiddleName) as CustomerName," +
                    " Employees.EmployeeID, CONCAT(Employees.LastName, + space(1) + Employees.FirstName, + space(1) + Employees.MiddleName) as EmployeeName," +
                    " Products.ProductID, Products.Name as ProductName," +
                    " ProductCategories.Name as ProductCategory" +
                    " from Orders " +
                    " left join Customers on Orders.CustomerID = Customers.CustomerID" +
                    " left join Employees on Orders.EmployeeID = Employees.EmployeeID" +
                    " left join Products on Orders.ProductID = Products.ProductID" +
                    " left join ProductCategories on Products.CategoryID = ProductCategories.CategoryID"
                        )
                    .ToList();
            }
        }
    }
}
