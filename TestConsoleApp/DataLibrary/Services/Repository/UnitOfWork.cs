using System;
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
            throw new NotImplementedException();
        }

        public static List<ExtendedOrder> GetAllExtendedOrders()
        {
            using (var connection = new SqlConnection(SqlConnect))
            {

                return connection.Query<ExtendedOrder>("Select Orders.OrderID, Customers.CustomerID, Employees.EmployeeID, Products.ProductID, CONCAT(Customers.LastName, + space(1) + Customers.FirstName, + space(1) + Customers.MiddleName) as CustomerName," +
                                                       " CONCAT(Employees.LastName, + space(1) + Employees.FirstName, + space(1) + Employees.MiddleName) as EmployeeName, Products.Name as ProductName," +
                                                       " Orders.Quantity, Orders.Price, Orders.OrderDate from Orders left join Customers on Orders.CustomerID = Customers.CustomerID" +
                                                       " left join Employees on Orders.EmployeeID = Employees.EmployeeID left join Products on Orders.ProductID = Products.ProductID")
                    .ToList();
            }
        }
    }
}
