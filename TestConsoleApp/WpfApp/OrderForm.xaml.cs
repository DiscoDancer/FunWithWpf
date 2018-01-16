using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using DataLibrary.Models.Entities;
using DataLibrary.Services.Repository;
using MoreLinq;
using WpfApp.ViewModels;

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

            DataContext = new OrderFormViewModel();
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
                var context = DataContext as OrderFormViewModel;
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
                    UnitOfWork.Orders.Update(order);
                }
                else
                {
                    UnitOfWork.Orders.Add(order);
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
