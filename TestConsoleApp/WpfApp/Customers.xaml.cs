using System;
using System.Collections.Generic;
using System.Windows;
using DataLibrary;
using DataLibrary.Models;
using DataLibrary.Models.Entities;
using DataLibrary.Services.Repository;
using WpfApp.Services;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for Customers.xaml
    /// </summary>
    public partial class Customers
    {
        private List<Customer> _customers = UnitOfWork.Customers.GetAll();

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
            StateService.CurrentCustomer = new Customer();
            Uri uri = new Uri("CustomerForm.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }


        private void DelCustomerBtn(object sender, RoutedEventArgs e)
        {
            var customer = ((FrameworkElement)sender).DataContext as Customer;
            UnitOfWork.Customers.Delete(customer);
            _customers = UnitOfWork.Customers.GetAll();
            CustomerDataGrid.ItemsSource = _customers;   
        }

        private void EditCustomerBtn(object sender, RoutedEventArgs e)
        {
            var customer = ((FrameworkElement)sender).DataContext as Customer;
            StateService.CurrentCustomer = customer;

            Uri uri = new Uri("CustomerForm.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);

            //var customer = ((FrameworkElement)sender).DataContext as Customer;
            //CustomerCRUD.UpdateCustomer(customer);
            //_customers = CustomerCRUD.GetAll();
            //CustomerDataGrid.ItemsSource = _customers;
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
