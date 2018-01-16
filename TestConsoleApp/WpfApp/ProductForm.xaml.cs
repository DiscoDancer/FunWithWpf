using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using DataLibrary.Models;
using DataLibrary.Models.Entities;
using DataLibrary.Services.Repository;
using MoreLinq;
using WpfApp.Services;
using WpfApp.ViewModels;

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
            DataContext = new ProductFormViewModel();
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

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var controlsTextBoxes = new[]
                {
                    TextBoxName
                };
                controlsTextBoxes.ForEach(x => x.GetBindingExpression(TextBox.TextProperty).UpdateSource());
                var controlsComboBoxes = new[]
                {
                    ListCategories
                };
                controlsComboBoxes.ForEach(x => x.GetBindingExpression(ComboBox.SelectedValueProperty).UpdateSource());

                var haveErrors = controlsTextBoxes
                    .Select(Validation.GetHasError)
                    .Concat(controlsComboBoxes.Select(Validation.GetHasError))
                    .Aggregate((x, y) => x || y);

                if (!haveErrors)
                {
                    var context = DataContext as ProductFormViewModel;
                    var product = context.Product;
                    product.CategoryID = context.CurrentCategory.ID;

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

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Products.xaml", UriKind.Relative));
        }
    }
}
