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
using System.Windows.Shapes;

namespace DemoListBinding
{
    /// <summary>
    /// Interaction logic for EditStudentWindow.xaml
    /// </summary>
    public partial class EditStudentWindow : Window
    {
        public delegate void CreditsChange(int newValue);
        public event CreditsChange Handler;

        public Student EditedStudent { get; set; } 

        public EditStudentWindow(Student info)
        {
            InitializeComponent();
            EditedStudent = (Student) info.Clone();
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {

            DialogResult = true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = EditedStudent;
        }

        private void creditsSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int newValue = (int) creditsSlider.Value;
          
            Handler?.Invoke(newValue);
        }
    }
}
