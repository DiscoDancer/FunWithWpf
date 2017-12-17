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
        public Customers()
        {
            InitializeComponent();
            CustomerDataGrid.ItemsSource = CustomerCRUD.GetAll();
        }

        private void CustomerDataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {

        }
        private void DeleteCustomer(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Deletion", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {

            }
            else
            {

            }

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
