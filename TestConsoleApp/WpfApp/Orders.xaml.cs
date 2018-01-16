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
    /// Interaction logic for Orders.xaml
    /// </summary>
    public partial class Orders
    {
        private List<ExtendedOrder> _orders = UnitOfWork.GetAllExtendedOrders();

        public Orders()
        {
            InitializeComponent();
            OrderDataGrid.ItemsSource = _orders;
        }

        private void DelOrderBtn(object sender, RoutedEventArgs e)
        {
            var order = ((FrameworkElement) sender).DataContext as Order;
            UnitOfWork.Orders.Delete(order);
            _orders = UnitOfWork.GetAllExtendedOrders();
            OrderDataGrid.ItemsSource = _orders;
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

        private void AddOrderBtn(object sender, RoutedEventArgs e)
        {
            StateService.CurrentOrder = new ExtendedOrder();
            Uri uri = new Uri("OrderForm.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }
    }
}
