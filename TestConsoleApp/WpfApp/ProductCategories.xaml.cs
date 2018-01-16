using System.Collections.Generic;
using System.Windows;
using System;
using DataLibrary.Models.Entities;
using DataLibrary.Services.Repository;
using WpfApp.Services;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for ProductCategories.xaml
    /// </summary>
    public partial class ProductCategories
    {
        private List<ProductCategory> _categories = UnitOfWork.ProductCategories.GetAll();

        public ProductCategories()
        {
            InitializeComponent();
            ProductCategoryDataGrid.ItemsSource = _categories;
        }

        private void AddCategoryBtn(object sender, RoutedEventArgs e)
        {
            StateService.CurrentCategory = new ProductCategory();
            Uri uri = new Uri("ProductCategoryForm.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void DelCategoryBtn(object sender, RoutedEventArgs e)
        {
            var category = ((FrameworkElement)sender).DataContext as ProductCategory;
            UnitOfWork.ProductCategories.Delete(category);
            _categories = UnitOfWork.ProductCategories.GetAll();
            ProductCategoryDataGrid.ItemsSource = _categories;
        }
        private void EditCategoryBtn(object sender, RoutedEventArgs e)
        {
            var category = ((FrameworkElement)sender).DataContext as ProductCategory;
            StateService.CurrentCategory = category;

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
            this.NavigationService.Navigate(new Uri("ProductCategories.xaml", UriKind.Relative));
        }
        private void ButtonOrders_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Orders.xaml", UriKind.Relative));
        }
        private void ButtonLogs_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Logs.xaml", UriKind.Relative));
        }
    }

}
