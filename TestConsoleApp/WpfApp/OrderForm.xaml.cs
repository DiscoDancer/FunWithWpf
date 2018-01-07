using DataLibrary;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using MoreLinq;
using WpfApp.Models;
using WpfApp.Services;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for OrderForm.xaml
    /// </summary>
    public partial class OrderForm : Page
    {
        public OrderForm()
        {
            InitializeComponent();

            DataContext = new OrderViewModel();
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
                ListCustomers,
                ListEmployees,
                ListProducts
            };

            controls.ForEach(x => x.GetBindingExpression(ComboBox.SelectedValueProperty).UpdateSource());
            var haveErrors = controls
                .Select(Validation.GetHasError)
                .Aggregate((x, y) => x || y);

            if (!haveErrors)
            {
                var context = DataContext as OrderViewModel;
                var orderExtended = context.Order;

                orderExtended.CustomerName = null;
                orderExtended.EmployeeName = null;
                orderExtended.ProductName = null;

                var order = (Order)orderExtended;

                order.CustomerID = context.CurrentCustomer.ID;
                order.EmployeeID = context.CurrentEmployee.ID;
                order.ProductID = context.CurrentProduct.ID;

                if (order.OrderID > 0)
                {
                    OrderCRUD.UpdateOrder(order);
                }
                else
                {

                    OrderCRUD.AddOrder(order);
                }

                this.NavigationService.Navigate(new Uri("Orders.xaml", UriKind.Relative));
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Orders.xaml", UriKind.Relative));
        }
    }
}
