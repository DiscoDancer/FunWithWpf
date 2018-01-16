using System;
using System.Windows;
using System.Windows.Controls;
using DataLibrary.Models;
using DataLibrary.Models.Entities;
using DataLibrary.Services.Repository;
using WpfApp.ViewModels;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for Page.xaml
    /// </summary>
    public partial class Home : Page
    {
        private readonly HomeViewModel _model = new HomeViewModel();

        public Home()
        {
            InitializeComponent();
            DataContext = _model;
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

        private void QueryExecute_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UnitOfWork.ExecuteRaw(_model.Query);
                MessageBox.Show("Sucessfully executed!");
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
                    LogText = $"Unhandled, message = {exception.Message}"
                });
                MessageBox.Show("Unsucessfully executed[Unhandled]! Please see logs!");
            }
        }
    }
}
