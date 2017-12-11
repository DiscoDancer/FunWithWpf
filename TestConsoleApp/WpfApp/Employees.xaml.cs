using System.Collections.Generic;
using System.Windows;
using DataLibrary;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for Employees.xaml
    /// </summary>
    public partial class Employees
    {
        public Employees()
        {
            InitializeComponent();
            EmployeeDataGrid.ItemsSource = EmployeeCRUD.GetAll();
        }
    }
}
