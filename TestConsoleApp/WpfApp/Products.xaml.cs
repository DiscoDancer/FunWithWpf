using System.Collections.Generic;
using System.Windows;
using DataLibrary;
using System.Linq;
using System;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for Products.xaml
    /// </summary>
    public partial class Products
    {
        private List<Product> _products = ProductCRUD.GetAll();
        public Products()
        {
            InitializeComponent();
            ProductDataGrid.ItemsSource = _products;
        }

        private void AddProductBtn(object sender, RoutedEventArgs e)
        {         
            _products.Add(new Product
            {
                Name = "Смартфон Nexus 5 16GB D821",
                Color = "Черный",
                Description = "Диагональ 4.95 дюйм / Фотокамера 8 МП / Процессор: четырехъядерный"
            });
            _products.Add(new Product
            {
                Name = "Смартфон Samsung Galaxy S8 64Gb",
                Color = "Желтый",
                Description = "Диагональ/разрешение:5.8 / 2960x1440 пикс / Количество ядер:	8"
            });
            _products.Add(new Product
            {
                Name = "Смартфон Huawei Honor 9",
                Color = "Серый",
                Description = "Двойная камера 20 МП + 12 МП / Full HD - экран 5.15 дюйма / 2 SIM - карты с 4G LTE Cat6"
            });
            ProductCRUD.AddProduct(_products.Last());
            _products = ProductCRUD.GetAll();
            ProductDataGrid.ItemsSource = _products;

        }

        private void DelCustomerBtn(object sender, RoutedEventArgs e)
        {
            ProductCRUD.DeleteProduct(_products.Last());
            _products = ProductCRUD.GetAll();
            ProductDataGrid.ItemsSource = _products;
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
