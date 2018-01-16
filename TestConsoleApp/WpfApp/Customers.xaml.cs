using System;
using System.Collections.Generic;
using System.Windows;
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
        private List<Customer> _customers;

        public Customers()
        {
            InitializeComponent();
            try
            {
                _customers = UnitOfWork.Customers.GetAll();
                CustomerDataGrid.ItemsSource = _customers;
            }
            catch (DataLibraryException exception)
            {
                UnitOfWork.Logs.Add(new Log
                {
                    LogText = $"query = {exception.Query}"
                });
                MessageBox.Show("Unsucessfully executed[Handled]! Please see logs!");

                return;
            }
            catch (Exception exception)
            {
                UnitOfWork.Logs.Add(new Log
                {
                    LogText = exception.Message
                });
                MessageBox.Show("Unhandled error! Please see logs!");
            }     
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
            try
            {
                var customer = ((FrameworkElement)sender).DataContext as Customer;
                UnitOfWork.Customers.Delete(customer);
                _customers = UnitOfWork.Customers.GetAll();
                CustomerDataGrid.ItemsSource = _customers;
            }
            catch (DataLibraryException exception)
            {
                UnitOfWork.Logs.Add(new Log
                {
                    LogText = $"query = {exception.Query}"
                });
                MessageBox.Show("Unsucessfully executed[Handled]! Please see logs!");

                return;
            }
            catch (Exception exception)
            {
                UnitOfWork.Logs.Add(new Log
                {
                    LogText = exception.Message
                });
                MessageBox.Show("Unhandled error! Please see logs!");
            }
        }

        private void EditCustomerBtn(object sender, RoutedEventArgs e)
        {
            var customer = ((FrameworkElement)sender).DataContext as Customer;
            StateService.CurrentCustomer = customer;
            Uri uri = new Uri("CustomerForm.xaml", UriKind.Relative);
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
