using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using DataLibrary;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for Customers.xaml
    /// </summary>
    public partial class Customers
    {
        private List<Customer> _customers = CustomerCRUD.GetAll();

        public Customers()
        {
            InitializeComponent();
            CustomerDataGrid.ItemsSource = _customers;
        }

        private void CustomerDataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }

        private void AddCustomerBtn(object sender, RoutedEventArgs e)
        {
            
            _customers.Add(new Customer
            {
                FirstName = "Валерий",
                MiddleName = "Егорович",
                LastName = "Жорин",
                Address = "Балтийская 28а, 34",
                City = "Кемерово",
                Phone = "89089252481"

            });
            _customers.Add(new Customer
            {
                FirstName = "Дмитрий",
                MiddleName = "Анатольевич",
                LastName = "Елкин",
                Address = "Вершовская 14",
                City = "Новосибирск",
                Phone = "89089148142"

            });
            _customers.Add(new Customer
            {
                FirstName = "Владимир",
                MiddleName = "Михайлович",
                LastName = "Копытин",
                Address = "Кирова 25а",
                City = "Кемерово",
                Phone = "89069325829"

            });
            CustomerCRUD.AddCustomer(_customers.Last());

            _customers = CustomerCRUD.GetAll();
            CustomerDataGrid.ItemsSource = _customers;
        }


        private void DelCustomerBtn(object sender, RoutedEventArgs e)
        {
            var customer = ((FrameworkElement)sender).DataContext as Customer;
            CustomerCRUD.DeleteCustomer(customer);
            _customers = CustomerCRUD.GetAll();
            CustomerDataGrid.ItemsSource = _customers;     
        }

        private void EditCustomerBtn(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("CustomerForm.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);

            //var customer = ((FrameworkElement)sender).DataContext as Customer;
            //CustomerCRUD.UpdateCustomer(customer);
            //_customers = CustomerCRUD.GetAll();
            //CustomerDataGrid.ItemsSource = _customers;
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
