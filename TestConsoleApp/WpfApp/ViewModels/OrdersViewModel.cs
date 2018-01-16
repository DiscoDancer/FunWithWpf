using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using WpfApp.Annotations;
using WpfApp.Services;

namespace WpfApp.ViewModels
{
    public class OrdersViewModel: INotifyPropertyChanged
    {
        public OrdersViewModel()
        {
            AllCategories = ComboBoxService.GetOptions(ComboBoxTargets.ProductCategories);
            AllCategories.Add(new NameID
            {
                Name = "All",
                ID = -1
            });
            CurrentCategory = AllCategories.Last();
        }

        public List<NameID> AllCategories { get; set; }

        public NameID CurrentCategory
        {
            get { return _currentCategory; }
            set
            {
                _currentCategory = value;
                OnPropertyChanged(nameof(CurrentCategory));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private NameID _currentCategory;
    }
}
