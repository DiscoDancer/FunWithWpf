using System.Collections.Generic;
using System.Windows;
using System;
using DataLibrary.Models.Entities;
using DataLibrary.Services.Repository;
using WpfApp.Services;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for ProductCategory.xaml
    /// </summary>
    public partial class ProductCategory
    {
        //private List<ProductCategory> _categories = UnitOfWork.ProductCategory.GetAll();
        public ProductCategory()
        {
            InitializeComponent();
        }

        private void AddCategoryBtn(object sender, RoutedEventArgs e)
        {
            StateService.CurrentCategory = new ProductCategory();
            Uri uri = new Uri("ProductCategoryForm.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void DelCategoryBtn(object sender, RoutedEventArgs e)
        {
            
        }
        private void EditCategoryBtn(object sender, RoutedEventArgs e)
        {
            var category = ((FrameworkElement)sender).DataContext as ProductCategory;
            StateService.CurrentCategory = category;
            Uri uri = new Uri("ProductForm.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }
    }
}
