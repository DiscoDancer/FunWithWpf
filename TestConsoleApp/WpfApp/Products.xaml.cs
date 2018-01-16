using System.Collections.Generic;
using System.Windows;
using System;
using DataLibrary.Models;
using DataLibrary.Models.Entities;
using DataLibrary.Services.Repository;
using WpfApp.Services;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for Products.xaml
    /// </summary>
    public partial class Products
    {
        private List<ExtendedProduct> _products = UnitOfWork.GetAllExtendedProducts();
        public Products()
        {
            InitializeComponent();
            ProductDataGrid.ItemsSource = _products;
        }

        private void AddProductBtn(object sender, RoutedEventArgs e)
        {
            StateService.CurrentProduct = new Product();
            Uri uri = new Uri("ProductForm.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void DelProductBtn(object sender, RoutedEventArgs e)
        {
            var product = ((FrameworkElement)sender).DataContext as Product;
            UnitOfWork.Products.Delete(product);
            _products = UnitOfWork.GetAllExtendedProducts();
            ProductDataGrid.ItemsSource = _products;
        }

        private void EditProductBtn(object sender, RoutedEventArgs e)
        {
            var extendedProduct = ((FrameworkElement)sender).DataContext as ExtendedProduct;
            extendedProduct.CategoryName = null;
            var product = (Product) extendedProduct;
            StateService.CurrentProduct = product;

            Uri uri = new Uri("ProductForm.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
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
        private void ButtonCategory_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("ProductCategories.xaml", UriKind.Relative));
        }
        private void ButtonOrders_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Orders.xaml", UriKind.Relative));
        }
    }
}
