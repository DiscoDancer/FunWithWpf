using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using DataLibrary.Models.Entities;
using DataLibrary.Services.Repository;
using MoreLinq;
using WpfApp.Services;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for ProductForm.xaml
    /// </summary>
    public partial class ProductForm : Page
    {
        public ProductForm()
        {
            InitializeComponent();
            DataContext = StateService.CurrentProduct;
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
            this.NavigationService.Navigate(new Uri("ProductCategory.xaml", UriKind.Relative));
        }
        private void ButtonOrders_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Orders.xaml", UriKind.Relative));
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            var controls = new[]
            {
                TextBoxName
            };

            controls.ForEach(x => x.GetBindingExpression(TextBox.TextProperty).UpdateSource());
            var haveErrors = controls
                .Select(Validation.GetHasError)
                .Aggregate((x, y) => x || y);

            if (!haveErrors)
            {
                var product = DataContext as Product;
                if (product.ProductID > 0)
                {
                    UnitOfWork.Products.Update(product);
                }
                else
                {
                    UnitOfWork.Products.Add(product);
                }

                this.NavigationService.Navigate(new Uri("Products.xaml", UriKind.Relative));
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Products.xaml", UriKind.Relative));
        }
    }
}
