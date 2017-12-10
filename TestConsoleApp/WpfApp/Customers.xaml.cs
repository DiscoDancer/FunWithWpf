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
    }
}
