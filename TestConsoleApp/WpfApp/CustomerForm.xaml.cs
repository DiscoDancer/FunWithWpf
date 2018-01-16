using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using DataLibrary;
using DataLibrary.Models;
using DataLibrary.Models.Entities;
using DataLibrary.Services.Repository;
using MoreLinq;
using WpfApp.Services;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for CustomerForm.xaml
    /// </summary>
    public partial class CustomerForm : Page
    {
        public CustomerForm()
        {
            InitializeComponent();
            DataContext = StateService.CurrentCustomer;
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

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            var controls = new[]
            {
                TextBoxFirstName,
                TextBoxMiddleName,
                TextBoxLastName
            };

            controls.ForEach(x => x.GetBindingExpression(TextBox.TextProperty).UpdateSource());
            var haveErrors = controls
                .Select(Validation.GetHasError)
                .Aggregate((x, y) => x || y);

            if (!haveErrors)
            {
                var customer = DataContext as Customer;
                if (customer.CustomerID > 0)
                {
                    UnitOfWork.Customers.Update(customer);
                }
                else
                {
                    UnitOfWork.Customers.Add(customer);
                }

                this.NavigationService.Navigate(new Uri("Customers.xaml", UriKind.Relative));
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Customers.xaml", UriKind.Relative));
        }
    }
}
