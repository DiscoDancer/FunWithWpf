using System.Collections.Generic;
using System.Linq;
using System.Windows;
using DataLibrary;
using System;

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
            
            _employees.Add(new Employee
            {
                FirstName = "AAAA",
                MiddleName = "BBBB",
                LastName = "CCCC",
                Salary = 100,
                PriorSalary = 50
                
            });
            EmployeeDataGrid.ItemsSource = _employees;
            EmployeeCRUD.AddEmployee(_employees.Last());

        }

        private void DelEmployeeBtn(object sender, RoutedEventArgs e)
        {
            EmployeeCRUD.DeleteEmployee(_employees.Last());
            _employees = EmployeeCRUD.GetAll();
            EmployeeDataGrid.ItemsSource = _employees;
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
