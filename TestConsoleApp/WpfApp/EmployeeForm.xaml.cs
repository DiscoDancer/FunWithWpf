using DataLibrary;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using DataLibrary.Models;
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
        private void ButtonOrders_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Orders.xaml", UriKind.Relative));
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
                    EmployeeCRUD.UpdateEmployee(employee);
                }
                else
                {
                    EmployeeCRUD.AddEmployee(DataContext as Employee);
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
