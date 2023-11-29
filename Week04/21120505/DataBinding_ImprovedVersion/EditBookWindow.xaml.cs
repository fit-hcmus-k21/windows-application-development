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

namespace DataBindingOneObject
{


        public partial class EditBookWindow : Window
        {

            public CBook EditedBook { get; set; }

        // Declare an event named BookEdited
        public event EventHandler<CBook> BookEdited;

        public EditBookWindow(CBook info)
            {
                InitializeComponent();
                EditedBook = (CBook)info.Clone();
            }

            private void okButton_Click(object sender, RoutedEventArgs e)
            {
                DialogResult = true;
            }

            private void Window_Loaded(object sender, RoutedEventArgs e)
            {
                DataContext = EditedBook;
            }

            private void nameTextBox_TextChanged(object sender, TextChangedEventArgs e)
            {
                // Update the Name property when the text changes in the TextBox
                EditedBook.Name = nameTextBox.Text;
            }

            private void authorTextBox_TextChanged(object sender, TextChangedEventArgs e)
            {
                // Update the Author property when the text changes in the TextBox
                EditedBook.Author = authorTextBox.Text;
            }

            private void publishedYearTextBox_TextChanged(object sender, TextChangedEventArgs e)
            {
            // Update the PublishedYear property when the text changes in the TextBox
            EditedBook.PublishedYear = int.Parse(publishedYearTextBox.Text);
            }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {


        }
    }
    }

