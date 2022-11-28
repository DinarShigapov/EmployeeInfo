using EmployeeTest.Components;
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

namespace EmployeeTest.Pages
{
    /// <summary>
    /// Логика взаимодействия для EmployeesListPage.xaml
    /// </summary>
    public partial class EmployeesListPage : Page
    {


        public EmployeesListPage()
        {
            InitializeComponent();
            EmployeeList.ItemsSource = DBConnect.db.Employee.ToList();
        }


        private void ShowInfo_Click(object sender, RoutedEventArgs e)
        {
            var showNextPage = (sender as Button).DataContext as Employee;
            Navigation.Update(new EmployeeInfoPage(showNextPage));
        }

        private void AddNewEmp_Click(object sender, RoutedEventArgs e)
        {
            Navigation.Update(new EmployeeInfoPage(new Employee()));
        }
    }
}
