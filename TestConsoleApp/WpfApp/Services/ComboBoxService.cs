using System;
using System.Collections.Generic;
using System.Linq;
using DataLibrary.Services.Repository;
using WpfApp.ViewModels;

namespace WpfApp.Services
{
    public static class ComboBoxService
    {
        public static List<NameID> GetOptions(ComboBoxTargets targets)
        {
            switch (targets)
            {
                case ComboBoxTargets.Customers:
                    return GetCustomerOptions();
                case ComboBoxTargets.Employees:
                    return GetEmployeesOptions();
                case ComboBoxTargets.Products:
                    return GetProductsOptions();
                case ComboBoxTargets.ProductCategories:
                    return GetProductCategoriesOptions();
                default:
                    throw new ArgumentOutOfRangeException(nameof(targets), targets, null);
            }
        }

        private static List<NameID> GetEmployeesOptions()
            => UnitOfWork.Employees.GetAll().Select(x => new NameID
            {
                ID = x.EmployeeID,
                Name = $"{x.FirstName} {x.MiddleName} {x.LastName}"
            }).ToList();

        private static List<NameID> GetProductsOptions()
            => UnitOfWork.Products.GetAll().Select(x => new NameID
            {
                ID = x.ProductID,
                Name = $"{x.Name}"
            }).ToList();

        private static List<NameID> GetCustomerOptions()
            => UnitOfWork.Customers.GetAll().Select(x => new NameID
            {
                ID = x.CustomerID,
                Name = $"{x.FirstName} {x.MiddleName} {x.LastName}"
            }).ToList();

        private static List<NameID> GetProductCategoriesOptions()
            => UnitOfWork.ProductCategories.GetAll().Select(x => new NameID
            {
                ID = x.CategoryID,
                Name = x.Name
            }).ToList();
    }
}
