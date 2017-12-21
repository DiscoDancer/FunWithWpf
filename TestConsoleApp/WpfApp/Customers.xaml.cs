using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using DataLibrary;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for Customers.xaml
    /// </summary>
    public partial class Customers
    {
        private List<Customer> _customers = CustomerCRUD.GetAll();

        public Customers()
        {
            InitializeComponent();
            CustomerDataGrid.ItemsSource = _customers;
        }

        private void CustomerDataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }

        private void AddCustomerBtn(object sender, RoutedEventArgs e)
        {
            
            _customers.Add(new Customer
            {
                FirstName = "AAAA",
                MiddleName = "BBBB",
                LastName = "CCCC"

            });
            CustomerDataGrid.ItemsSource = _customers;
            CustomerCRUD.AddCustomer(_customers.Last());
            
        }

        private void DelCustomerBtn(object sender, RoutedEventArgs e)
        {
            CustomerCRUD.DeleteCustomer(_customers.Last());
            _customers = CustomerCRUD.GetAll();
            CustomerDataGrid.ItemsSource = _customers;
            
        }

        private void EditCustomer(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Editing", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {

            }
            else
            {

            }

        }
    }
}
