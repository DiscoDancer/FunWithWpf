using DataLibrary;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for Orders.xaml
    /// </summary>
    public partial class Orders
    {
        public Orders()
        {
            InitializeComponent();
            OrderDataGrid.ItemsSource = OrderCRUD.GetAll();

        }
    }
}
