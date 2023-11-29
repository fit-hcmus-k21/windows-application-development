using System;
using System.Windows;
using System.Windows.Controls;

namespace DataBindingOneObject
{
    public partial class EditEmployeeWindow : Window
    {
        public CEmployee EditedEmployee { get; set; }

        // Declare an event named EmployeeEdited
        public event EventHandler<CEmployee> EmployeeEdited;

        public EditEmployeeWindow(CEmployee info)
        {
            InitializeComponent();
            EditedEmployee = (CEmployee)info.Clone();
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            EmployeeEdited?.Invoke(this, EditedEmployee);
            DialogResult = true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = EditedEmployee;
        }

        private void fullNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Update the FullName property when the text changes in the TextBox
            EditedEmployee.FullName = fullNameTextBox.Text;
        }

        private void emailTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Update the Email property when the text changes in the TextBox
            EditedEmployee.Email = emailTextBox.Text;
        }

        private void phoneNumberTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Update the PhoneNumber property when the text changes in the TextBox
            EditedEmployee.PhoneNumber = phoneNumberTextBox.Text;
        }

        private void addressTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Update the Address property when the text changes in the TextBox
            EditedEmployee.Address = addressTextBox.Text;
        }


        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            // Add any additional logic for the cancel button if needed
            DialogResult = false;
        }
    }
}
