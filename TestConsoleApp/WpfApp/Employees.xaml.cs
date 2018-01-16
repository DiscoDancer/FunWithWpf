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
    /// Interaction logic for Employees.xaml
    /// </summary>
    public partial class Employees
    {
        private List<Employee> _employees;

        public Employees()
        {
            InitializeComponent();
            try
            {
                _employees = UnitOfWork.Employees.GetAll();
                EmployeeDataGrid.ItemsSource = _employees;
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
        private void AddEmployeeBtn(object sender, RoutedEventArgs e)
        {
            StateService.CurrentEmployee = new Employee();
            var uri = new Uri("EmployeeForm.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void DelEmployeeBtn(object sender, RoutedEventArgs e)
        {
            try
            {
                var employee = ((FrameworkElement)sender).DataContext as Employee;
                UnitOfWork.Employees.Delete(employee);
                _employees = UnitOfWork.Employees.GetAll();
                EmployeeDataGrid.ItemsSource = _employees;
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

        private void EditEmployeeBtn(object sender, RoutedEventArgs e)
        {
            var employee = ((FrameworkElement)sender).DataContext as Employee;
            StateService.CurrentEmployee = employee;

            var uri = new Uri("EmployeeForm.xaml", UriKind.Relative);
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

        private void ButtonHome_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Home.xaml", UriKind.Relative));
        }
    }

}
