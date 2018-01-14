using System.Collections.Generic;
using System.Windows;
using System;
using DataLibrary.Models.Entities;
using DataLibrary.Services.Repository;
using WpfApp.Services;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for ProductCategory.xaml
    /// </summary>
    public partial class ProductCategory
    {
        //private List<ProductCategory> _category = UnitOfWork.ProductCategory.GetAll();
        public ProductCategory()
        {
            InitializeComponent();
        }

        private void AddCategoryBtn(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("ProductCategoryForm.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void DelCategoryBtn(object sender, RoutedEventArgs e)
        {
            
        }
        private void EditCategoryBtn(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("ProductCategoryForm.xaml", UriKind.Relative);
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
            this.NavigationService.Navigate(new Uri("ProductCategory.xaml", UriKind.Relative));
        }
        private void ButtonOrders_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Orders.xaml", UriKind.Relative));
        }
    }

}
