using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DataBindingOneObject
{
    /// <summary>
    /// Interaction logic for ListEmployees.xaml
    /// </summary>
    public partial class ListEmployeesWindow : Window
    {
        public ListEmployeesWindow()
        {
            InitializeComponent();
        }



        BindingList<CEmployee> _employees;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _employees = new BindingList<CEmployee>()
            {

            };

            for (int i = 1; i <= 10; i++)
            {
                string id;
                if (i < 10)
                {
                    id = "00" + i;
                }
                else
                {
                    id = "0" + i;
                }

                string fullName = GetRandomFullName();

                // remove all spaces
                string fullNameFilter = GetFilterFromFullName(fullName);
                

                string email = $"{fullNameFilter}.{i}@gmail.com";
                string address = GetRandomAddress();
                string phoneNumber = GetRandomPhoneNumber();
                string idPathAvatar;
                if (i < 10)
                {
                    idPathAvatar = "0" + i;
                }
                else
                {
                    idPathAvatar = i.ToString();
                }
                string avatar = $"assets/employees/{idPathAvatar}.jpg";

                CEmployee employee = new CEmployee()
                {
                    ID = id,
                    FullName = fullName,
                    Email = email,
                    Address = address,
                    PhoneNumber = phoneNumber,
                    Avatar = avatar
                };

                _employees.Add(employee);

                employeesComboBox.ItemsSource = _employees;
            }
        }

        static string GetFilterFromFullName(string fullName)
        {
            string[] words = fullName.Split(' ');
            string filter = string.Join("", words.Select(word => word[0]));

            return filter.ToLower(); // Optionally convert to lowercase
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            CEmployee employee = new CEmployee()
            {
                ID = "022",
                FullName = "Trần Khởi My",
                Email = "khoimy9x@gmail.com",
                Address = "Đồng Nai, Việt Nam",
                PhoneNumber = "0933602316",
                Avatar = "assets/employees/09.jpg"
            };

            _employees.Add(employee);



            MessageBox.Show("added");
        }

        static string GetRandomFullName()
        {
            string[] firstNames = { "Nguyễn", "Trần", "Lê", "Phạm", "Hoàng", "Huỳnh", "Phan", "Vũ", "Võ", "Đặng" };
            string[] lastNames = { "Văn Thái", "Thị Kiều", "Hữu Huy", "Ngọc Thiện", "Quang Minh", "Thanh Hoa", "Minh Khải", "Hải Hoàng", "Thành Đạt", "Nghĩa Khang" };

            Random rand = new Random();
            string fullName = $"{firstNames[rand.Next(firstNames.Length)]} {lastNames[rand.Next(lastNames.Length)]}";

            return fullName;
        }

        static string GetRandomAddress()
        {
            string[] streets = { "Nguyễn Huệ", "Lê Lợi", "Trần Hưng Đạo", "Hồ Xuân Hương", "Ngô Gia Tự", "Bà Huyện Thanh Quan", "Lý Thường Kiệt", "Phan Châu Trinh", "Nguyễn Thị Minh Khai" };
            string[] cities = { "Hà Nội", "Hồ Chí Minh", "Đà Nẵng", "Hải Phòng", "Cần Thơ", "Huế", "Nha Trang", "Vũng Tàu", "Đà Lạt" };

            Random rand = new Random();
            string address = $"{cities[rand.Next(cities.Length)]}"; //, {streets[rand.Next(streets.Length)]}

            return address;
        }

        static string GetRandomPhoneNumber()
        {
            Random rand = new Random();
            string phoneNumber = $"0{rand.Next(100000000, 999999999)}";

            return phoneNumber;
        }

        private void removeButton_Click(object sender, RoutedEventArgs e)
        {
            int i = employeesComboBox.SelectedIndex;
            _employees.RemoveAt(i);
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            int i = employeesComboBox.SelectedIndex;
            _employees[i].ID = "022";
            _employees[i].Avatar = "assets/employees/05.jpg";
            _employees[i].FullName = "Róse Park";
            _employees[i].Email = "rose.blackpink@gmail.com";
            _employees[i].Address = "Hàn Quốc";
            _employees[i].PhoneNumber = "0933251736";

        }

        private void deleteMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var employee = (CEmployee)employeesComboBox.SelectedItem;
            _employees.Remove(employee);
        }

        CEmployee _backup;

        private void editMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var employee = (CEmployee)employeesComboBox.SelectedItem;

            // CEmployee class has properties ID, FullName, Email, PhoneNumber, Address, and Avatar
            var backup = (CEmployee)employee.Clone();

            var screen = new EditEmployeeWindow(employee);

            // EditEmployeeWindow has an event named EmployeeEdited
            screen.EmployeeEdited += (sender, editedEmployee) =>
            {
                // Update properties based on your CEmployee class
                employee.FullName = editedEmployee.FullName;
                employee.Email = editedEmployee.Email;
                employee.PhoneNumber = editedEmployee.PhoneNumber;
                employee.Address = editedEmployee.Address;
                employee.Avatar = editedEmployee.Avatar;
            };

            if (screen.ShowDialog() == true)
            {
                // Implement a CopyProperties method in your CEmployee class
                screen.EditedEmployee.CopyProperties(employee);
            }
            else
            {
                // Implement a CopyProperties method in your CEmployee class
                backup.CopyProperties(employee);
            }
        }



        private void employeesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
