using DataLibrary;
using DataLibrary.Models;

namespace WpfApp.Services
{
    public static class StateService
    {
        public static Customer CurrentCustomer { get; set; }
        public static Employee CurrentEmployee { get; set; }
        public static Product CurrentProduct { get; set; }
        public static OrderExtended CurrentOrder { get; set; }
    }
}
