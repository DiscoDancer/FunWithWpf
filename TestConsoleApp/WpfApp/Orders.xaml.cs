using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using DataLibrary.Models;
using DataLibrary.Models.Entities;
using DataLibrary.Services.Repository;
using WpfApp.Services;
using WpfApp.ViewModels;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for Orders.xaml
    /// </summary>
    public partial class Orders
    {
        private List<ExtendedOrder> _orders;

        public Orders()
        {
            InitializeComponent();

            try
            {
                _orders = UnitOfWork.GetAllExtendedOrders();
                var model = new OrdersViewModel();

                OrderDataGrid.ItemsSource = _orders;
                DataContext = model;

                model.PropertyChanged += (sender, args) =>
                {
                    OrderDataGrid.ItemsSource = model.CurrentCategory.ID > 0
                        ? _orders.Where(x => x.ProductCategory == model.CurrentCategory.Name)
                        : _orders;
                };
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

        private void DelOrderBtn(object sender, RoutedEventArgs e)
        {
            try
            {
                var order = ((FrameworkElement)sender).DataContext as Order;
                UnitOfWork.Orders.Delete(order);
                _orders = UnitOfWork.GetAllExtendedOrders();
                OrderDataGrid.ItemsSource = _orders;
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

        private void EditOrderBtn(object sender, RoutedEventArgs e)
        {
            var order = ((FrameworkElement) sender).DataContext as ExtendedOrder;
            StateService.CurrentOrder = order;
            Uri uri = new Uri("OrderForm.xaml", UriKind.Relative);
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

        private void AddOrderBtn(object sender, RoutedEventArgs e)
        {
            StateService.CurrentOrder = new ExtendedOrder();
            Uri uri = new Uri("OrderForm.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }
    }
}
