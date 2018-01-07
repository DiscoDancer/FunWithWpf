using System.Collections.Generic;
using System.Linq;
using System.Windows;
using DataLibrary;
using System;
using DataLibrary.Models;
using WpfApp.Services;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for Employees.xaml
    /// </summary>
    public partial class Employees
    {
        private List<Employee> _employees = EmployeeCRUD.GetAll();

        public Employees()
        {
            InitializeComponent();
            EmployeeDataGrid.ItemsSource = _employees;
        }
        private void AddEmployeeBtn(object sender, RoutedEventArgs e)
        {
            StateService.CurrentEmployee = new Employee();
            Uri uri = new Uri("EmployeeForm.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void DelEmployeeBtn(object sender, RoutedEventArgs e)
        {
            var employee = ((FrameworkElement)sender).DataContext as Employee;
            EmployeeCRUD.DeleteEmployee(employee);
            _employees = EmployeeCRUD.GetAll();
            EmployeeDataGrid.ItemsSource = _employees;
        }

        private void EditEmployeeBtn(object sender, RoutedEventArgs e)
        {
            var employee = ((FrameworkElement)sender).DataContext as Employee;
            StateService.CurrentEmployee = employee;

            Uri uri = new Uri("EmployeeForm.xaml", UriKind.Relative);
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
        private void ButtonOrders_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Orders.xaml", UriKind.Relative));
        }
    }

}
