using System.Collections.Generic;
using System.Linq;
using DataLibrary.Models.Entities;
using WpfApp.Services;

namespace WpfApp.ViewModels
{
    public class ProductFormViewModel
    {
        public ProductFormViewModel()
        {
            Product = StateService.CurrentProduct;
            AllCategories = ComboBoxService.GetOptions(ComboBoxTargets.ProductCategories);
            CurrentCategory = AllCategories.FirstOrDefault(x => x.ID == Product.CategoryID);
        }

        public Product Product { get; set; }
        public List<NameID> AllCategories { get; set; }
        public NameID CurrentCategory { get; set; }
    }
}
