using EmployeeTest.Components;
using Microsoft.SqlServer.Server;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
                employee.PrefixId = PrefixCb.SelectedIndex + 1;
                employee.StateId = StateCb.SelectedIndex + 1;
                employee.StatusId = StatusCb.SelectedIndex + 1;
                employee.DepartmentId = DepartmentCb.SelectedIndex + 1;
                DBConnect.db.SaveChanges();
            }
            catch (Exception)
            {
                MessageBox.Show($"Произошла ошибка", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            finally 
            {
            }

        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigation.Update(new EmployeesListPage());
        }

        private void AddImageBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "*.png|*.png|*.jpg|*.jpg|*.jpeg|*.jpeg"
            };

            if (openFileDialog.ShowDialog().GetValueOrDefault())
            {
                employee.MainPhoto = File.ReadAllBytes(openFileDialog.FileName);
                EmployeeImg.Source = new BitmapImage(new Uri(openFileDialog.FileName));
            }
        }

        private void DateFormat_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            txtHideDate.MaxLength = 10;

            if (!(Char.IsDigit(e.Text, 0) || (e.Text == "/") && (!txtHideDate.Text.Contains("//") && txtHideDate.Text.Length != 0)))
            {
                e.Handled = true;
            }
        }
    }
}
