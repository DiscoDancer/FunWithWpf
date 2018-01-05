using DataLibrary;

namespace WpfApp.Services
{
    public static class StateService
    {
        public static Customer CurrentCustomer { get; set; }
        public static Employee CurrentEmployee { get; set; }
        public static Product CurrentProduct { get; set; }
        public static Order CurrentOrder { get; set; }
    }
}
