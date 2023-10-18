using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace DemoListBinding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        BindingList<Student> _students;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _students = new BindingList<Student>()
            {
                new Student() { ID = "001", Credits=10, Name="Trần Khôi Hồ",     Avatar="assets/avatar01.jpg"},
                new Student() { ID = "002", Credits=10, Name="Nguyễn Thư Hoàng", Avatar="assets/avatar02.jpg"},
                new Student() { ID = "003", Credits=10, Name="Cao Khôi Nguyễn",  Avatar="assets/avatar03.jpg"},
                new Student() { ID = "004", Credits=10, Name="Lê Duy Đoàn",      Avatar="assets/avatar04.jpg"},
                new Student() { ID = "005", Credits=10, Name="Đặng Diệp Thảo",   Avatar="assets/avatar05.jpg"},
                new Student() { ID = "006", Credits=10, Name="Trần Khôi Hồ",     Avatar="assets/avatar01.jpg"},
                new Student() { ID = "007", Credits=10, Name="Nguyễn Thư Hoàng", Avatar="assets/avatar02.jpg"},
                new Student() { ID = "008", Credits=10, Name="Cao Khôi Nguyễn",  Avatar="assets/avatar03.jpg"},
                new Student() { ID = "009", Credits=10, Name="Lê Duy Đoàn",      Avatar="assets/avatar04.jpg"},
                new Student() { ID = "010", Credits=10, Name="Đặng Diệp Thảo",   Avatar="assets/avatar05.jpg"},
                new Student() { ID = "011", Credits=10, Name="Trần Khôi Hồ",     Avatar="assets/avatar01.jpg"},
                new Student() { ID = "012", Credits=10, Name="Nguyễn Thư Hoàng", Avatar="assets/avatar02.jpg"},
                new Student() { ID = "013", Credits=10, Name="Cao Khôi Nguyễn",  Avatar="assets/avatar03.jpg"},
                new Student() { ID = "014", Credits=10, Name="Lê Duy Đoàn",      Avatar="assets/avatar04.jpg"},
                new Student() { ID = "015", Credits=10, Name="Đặng Diệp Thảo",   Avatar="assets/avatar05.jpg"}
            };

            studentsComboBox.ItemsSource = _students;
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            _students.Add(new Student()
            {
                ID = "006",
                Name = "Đinh Bách Phan",
                Avatar = "assets/avatar06.jpg"
            });
            MessageBox.Show("added");
        }

        private void removeButton_Click(object sender, RoutedEventArgs e)
        {
            int i = studentsComboBox.SelectedIndex;
            _students.RemoveAt(i);
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            int i = studentsComboBox.SelectedIndex;
            _students[i].ID = "009";
            _students[i].Avatar = "assets/avatar07.jpg";
        }

        private void deleteMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var student = (Student) studentsComboBox.SelectedItem;
            _students.Remove(student);
        }

        Student _backup;
        private void editMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var student = (Student)studentsComboBox.SelectedItem;
            _backup = (Student) student.Clone();
            var screen = new EditStudentWindow(student);
            screen.Handler += (int newValue) =>
            {
                student.Credits = newValue;
            };

            if (screen.ShowDialog()!.Value == true)
            {
                screen.EditedStudent.CopyProperties(student);
            } else
            {
                _backup.CopyProperties(student);
            }
        }


        private void studentsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
