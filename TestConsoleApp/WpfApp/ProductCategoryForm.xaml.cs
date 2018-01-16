using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DataLibrary.Services.Repository;
using MoreLinq;
using WpfApp.Services;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for ProductCategoryForm.xaml
    /// </summary>
    public partial class ProductCategoryForm : Page
    {
        public ProductCategoryForm()
        {
            InitializeComponent();
            DataContext = StateService.CurrentCategory;
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
                TextBoxName
            };

            controls.ForEach(x => x.GetBindingExpression(TextBox.TextProperty).UpdateSource());
            var haveErrors = controls
                .Select(Validation.GetHasError)
                .Aggregate((x, y) => x || y);

            if (!haveErrors)
            {
                var z = DataContext;
                var category = DataContext as DataLibrary.Models.Entities.ProductCategory;
                if (category.CategoryID > 0)
                {
                    UnitOfWork.ProductCategories.Update(category);
                }
                else
                {
                    UnitOfWork.ProductCategories.Add(category);
                }

                this.NavigationService.Navigate(new Uri("ProductCategories.xaml", UriKind.Relative));
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("ProductCategories.xaml", UriKind.Relative));
        }
    }
}
