using EmployeeTest.Components;
using Microsoft.SqlServer.Server;
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
    /// Логика взаимодействия для EmployeeInfoPage.xaml
    /// </summary>
    public partial class EmployeeInfoPage : Page
    {
        Employee employee;

        public EmployeeInfoPage(Employee _employee)
        {
            InitializeComponent();
            employee = _employee;
            this.DataContext = employee;
            InitializeComboBox();

        }

        private void InitializeComboBox()
        {
            PrefixCb.ItemsSource = DBConnect.db.Prefix.ToList();
            StateCb.ItemsSource = DBConnect.db.State.ToList();
            DepartmentCb.ItemsSource = DBConnect.db.Departament.ToList();
            StatusCb.ItemsSource = DBConnect.db.Status.ToList();

            if (employee.PrefixId != null)
                PrefixCb.SelectedIndex = employee.PrefixId.Value - 1;
            if (employee.StateId != null)
                StateCb.SelectedIndex = employee.StateId.Value - 1;
            if (employee.DepartmentId != null)
                DepartmentCb.SelectedIndex = employee.DepartmentId.Value - 1;
            if (employee.StatusId != null)
                StatusCb.SelectedIndex = employee.StatusId.Value - 1;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                employee.FirstName = txtFirstName.Text;
                employee.LastName = txtLastName.Text;
                employee.PrefixId = PrefixCb.SelectedIndex + 1;
                employee.Title = txtTitle.Text;
                DBConnect.db.SaveChanges();
            }
            catch (Exception)
            {
                MessageBox.Show("Произошла ошибка", "Внимание");
            }
            finally {}
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigation.Update(new EmployeesListPage());
        }
    }
}
