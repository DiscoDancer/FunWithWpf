﻿using System;
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
        public static IRepository<Log> Logs { get; } = new LogRepository();

        private static readonly string SqlConnect = ConnectionStringsService.Resolve();

        public static List<ExtendedProduct> GetAllExtendedProducts()
        {
            var query =
                " Select Products.ProductID, Products.CategoryID, Products.Name, Products.Color, Products.Description," +
                " ProductCategories.Name as CategoryName" +
                " From Products" +
                " Inner Join ProductCategories" +
                " On Products.CategoryID = ProductCategories.CategoryID";

            try
            {
                using (var connection = new SqlConnection(SqlConnect))
                {
                    return connection.Query<ExtendedProduct>(query).ToList();
                }
            }
            catch (Exception e)
            {
                throw new DataLibraryException
                {
                    Query = query
                };
            }

        }

        public static void ExecuteRaw(string query)
        {
            try
            {
                using (var connection = new SqlConnection(SqlConnect))
                {
                    connection.Query(query);
                }
            }
            catch (Exception e)
            {
                throw new DataLibraryException
                {
                    Query = query,
                };
            }

        }

        public static List<ExtendedOrder> GetAllExtendedOrders()
        {
            var query =
                " Select" +
                " Orders.OrderID, Orders.Quantity, Orders.Price, Orders.OrderDate," +
                " Customers.CustomerID, CONCAT(Customers.LastName, + space(1) + Customers.FirstName, + space(1) + Customers.MiddleName) as CustomerName," +
                " Employees.EmployeeID, CONCAT(Employees.LastName, + space(1) + Employees.FirstName, + space(1) + Employees.MiddleName) as EmployeeName," +
                " Products.ProductID, Products.Name as ProductName," +
                " ProductCategories.Name as ProductCategory" +
                " from Orders " +
                " Inner join Customers on Orders.CustomerID = Customers.CustomerID" +
                " Inner join Employees on Orders.EmployeeID = Employees.EmployeeID" +
                " Inner join Products on Orders.ProductID = Products.ProductID" +
                " Inner join ProductCategories on Products.CategoryID = ProductCategories.CategoryID";

            try
            {
                using (var connection = new SqlConnection(SqlConnect))
                {
                    return connection.Query<ExtendedOrder>(query).ToList();
                }
            }
            catch (Exception e)
            {
                throw new DataLibraryException
                {
                    Query = query
                };
            }

        }
    }
}
