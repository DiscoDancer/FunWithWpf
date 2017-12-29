using DataLibrary;
using System;
using System.Collections.Generic;
using System.Windows;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for Orders.xaml
    /// </summary>
    public partial class Orders
    {
        private List<Order> _orders = OrderCRUD.GetAll();
        public Orders()
        {
            InitializeComponent();
            OrderDataGrid.ItemsSource = _orders;

        }
        private void DelOrderBtn(object sender, RoutedEventArgs e)
        {
            var order = ((FrameworkElement)sender).DataContext as Order;
            OrderCRUD.DeleteOrder(order);
            _orders = OrderCRUD.GetAll();
            OrderDataGrid.ItemsSource = _orders;
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
