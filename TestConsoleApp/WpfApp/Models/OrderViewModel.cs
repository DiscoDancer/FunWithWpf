using System.Collections.Generic;
using System.Linq;
using DataLibrary.Models;
using WpfApp.Services;

namespace WpfApp.Models
{
    public class OrderViewModel
    {
        public OrderViewModel()
        {
            Order = StateService.CurrentOrder;
            AllCustomers = ComboBoxService.GetOptions(ComboBoxTargets.Customers);
            CurrentCustomer = AllCustomers.FirstOrDefault(x => x.ID == Order.CustomerID);
            AllEmployees = ComboBoxService.GetOptions(ComboBoxTargets.Employees);
            CurrentEmployee = AllEmployees.FirstOrDefault(x => x.ID == Order.EmployeeID);
            AllProducts = ComboBoxService.GetOptions(ComboBoxTargets.Products);
            CurrentProduct = AllProducts.FirstOrDefault(x => x.ID == Order.ProductID);
        }

        public ExtendedOrder Order { get; set; }
        public List<NameID> AllCustomers { get; set; }
        public NameID CurrentCustomer { get; set; }
        public List<NameID> AllEmployees { get; set; }
        public NameID CurrentEmployee { get; set; }
        public List<NameID> AllProducts { get; set; }
        public NameID CurrentProduct { get; set; }

    }
}
