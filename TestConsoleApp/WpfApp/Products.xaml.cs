using System.Collections.Generic;
using System.Windows;
using DataLibrary;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for Products.xaml
    /// </summary>
    public partial class Products
    {
        public Products()
        {
            InitializeComponent();
            ProductDataGrid.ItemsSource = ProductCRUD.GetAll();
        }
    }
}
