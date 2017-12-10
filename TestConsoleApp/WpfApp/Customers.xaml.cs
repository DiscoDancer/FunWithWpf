using System.Collections.Generic;
using System.Windows;
using DataLibrary;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for Customers.xaml
    /// </summary>
    public partial class Customers
    {
        public List<Customer> CustomersList { get; }

        public Customers()
        {
            InitializeComponent();
            CustomersList = CustomerCRUD.GetAll();

            CustomerDataGrid.ItemsSource = CustomersList;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
