using DataLibrary;
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
        }

        public Order Order { get; set; }
        public List<NameID> AllCustomers { get; set; }
        public NameID CurrentCustomer { get; set; }
    }
}
