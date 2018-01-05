﻿using DataLibrary;
using System.Collections.Generic;
using System.Linq;
using WpfApp.Services;

namespace WpfApp.Models
{
    public class OrderViewModel
    {
        public OrderViewModel()
        {
            Order = StateService.CurrentOrder;
            AllCustomers = CustomerCRUD.GetNameIds();
            CurrentCustomer = AllCustomers.FirstOrDefault(x => x.ID == Order.CustomerID);
            AllEmployees = EmployeeCRUD.GetNameIds();
            CurrentEmployee = AllEmployees.FirstOrDefault(x => x.ID == Order.EmployeeID);
            AllProducts = ProductCRUD.GetNameIds();
            CurrentProduct = AllProducts.FirstOrDefault(x => x.ID == Order.ProductID);
        }

        public Order Order { get; set; }
        public List<NameID> AllCustomers { get; set; }
        public NameID CurrentCustomer { get; set; }
        public List<NameID> AllEmployees { get; set; }
        public NameID CurrentEmployee { get; set; }
        public List<NameID> AllProducts { get; set; }
        public NameID CurrentProduct { get; set; }

    }
}
