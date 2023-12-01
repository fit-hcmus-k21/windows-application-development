using System;
using System.Windows;
using System.Windows.Controls;

namespace DataBindingOneObject
{
    public partial class EditPhoneWindow : Window
    {
        public CPhone EditedPhone { get; set; }

        // Declare an event named PhoneEdited
        public event EventHandler<CPhone> PhoneEdited;

        public EditPhoneWindow(CPhone info)
        {
            InitializeComponent();
            EditedPhone = (CPhone)info.Clone();
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            PhoneEdited?.Invoke(this, EditedPhone);
            DialogResult = true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = EditedPhone;
        }

        private void nameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Update the Name property when the text changes in the TextBox
            EditedPhone.Name = nameTextBox.Text;
        }

        private void manufacturerTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Update the Manufacturer property when the text changes in the TextBox
            EditedPhone.Manufacturer = manufacturerTextBox.Text;
        }

        private void priceTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Update the Price property when the text changes in the TextBox
            int price;
            if (int.TryParse(priceTextBox.Text, out price))
            {
                EditedPhone.Price = price;
            }
            else
            {
                // Handle invalid input (non-numeric)
                // You may want to show an error message or handle this case based on your requirements.
            }
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            // Add any additional logic for the cancel button if needed
            DialogResult = false;
        }
    }
}
