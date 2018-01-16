using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using DataLibrary.Models.Entities;
using DataLibrary.Services.Repository;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for Logs.xaml
    /// </summary>
    public partial class Logs : Page
    {
        private readonly List<Log> _logs = UnitOfWork.Logs.GetAll();

        public Logs()
        {
            InitializeComponent();
            LogsDataGrid.ItemsSource = _logs;
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
