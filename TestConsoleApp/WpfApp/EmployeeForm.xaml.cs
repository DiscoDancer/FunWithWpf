using DataLibrary;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using DataLibrary.Models;
using DataLibrary.Models.Entities;
using DataLibrary.Services.Repository;
using MoreLinq;
using WpfApp.Services;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for EmployeeForm.xaml
    /// </summary>
    public partial class EmployeeForm : Page
    {
        public EmployeeForm()
        {
            InitializeComponent();
            DataContext = StateService.CurrentEmployee;
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
                var employee = DataContext as Employee;
                if (employee.EmployeeID > 0)
                {
                    UnitOfWork.Employees.Update(employee);
                }
                else
                {
                    UnitOfWork.Employees.Add(employee);
                }
                this.NavigationService.Navigate(new Uri("Employees.xaml", UriKind.Relative));
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Employees.xaml", UriKind.Relative));
        }
    }
}
