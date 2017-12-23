using System.Collections.Generic;
using System.Windows;
using DataLibrary;
using System.Linq;
using System;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for Products.xaml
    /// </summary>
    public partial class Products
    {
        private List<Product> _products = ProductCRUD.GetAll();
        public Products()
        {
            InitializeComponent();
            ProductDataGrid.ItemsSource = _products;
        }

        private void AddProductBtn(object sender, RoutedEventArgs e)
        {         
            _products.Add(new Product
            {
                Name = "AAAA",
                Description = "BBBB"
            });
            ProductDataGrid.ItemsSource = _products;
            ProductCRUD.AddProduct(_products.Last());

        }

        private void DelCustomerBtn(object sender, RoutedEventArgs e)
        {
            ProductCRUD.DeleteProduct(_products.Last());
            _products = ProductCRUD.GetAll();
            ProductDataGrid.ItemsSource = _products;
        }
        private void ButtonCustomers_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Customers.xaml", UriKind.Relative));
        }
        private void ButtonEmployees_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Employees.xaml", UriKind.Relative));
        }
        private void ButtonProducts_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Products.xaml", UriKind.Relative));
        }
        private void ButtonOrders_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Orders.xaml", UriKind.Relative));
        }
    }
}
