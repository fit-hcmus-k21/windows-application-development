﻿using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
using Path = System.IO.Path;

namespace DataBindingOneObject
{


        public partial class AddBookWindow : Window
        {

            public CBook newBook { get; set; }

        // Declare an event named newBook
        //public event EventHandler<CBook> newBook;

        public AddBookWindow(int totalBooks)
            {
                InitializeComponent();
                newBook = new CBook();
                newBook.ID = totalBooks + 1;
            }

            private void addButton_Click(object sender, RoutedEventArgs e)
            {
            // check if name field is empty, then show message box
            if (string.IsNullOrEmpty(newBook.Name))
            {
                MessageBox.Show("Name field cannot be empty. Please enter a name.");
                return;
            }
            DialogResult = true;
            }

            private void Window_Loaded(object sender, RoutedEventArgs e)
            {
                DataContext = newBook;
            }

            private void nameTextBox_TextChanged(object sender, TextChangedEventArgs e)
            {
                // Update the Name property when the text changes in the TextBox
                newBook.Name = nameTextBox.Text;
            }

            private void authorTextBox_TextChanged(object sender, TextChangedEventArgs e)
            {
                // Update the Author property when the text changes in the TextBox
                newBook.Author = authorTextBox.Text;
            }

            private void publishedYearTextBox_TextChanged(object sender, TextChangedEventArgs e)
            {
            // Update the PublishedYear property when the text changes in the TextBox
            newBook.PublishedYear = int.Parse(publishedYearTextBox.Text);
            }

        private void priceTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Update the Price property when the text changes in the TextBox
            newBook.Price = int.Parse(priceTextBox.Text);
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult= false;

        }



        private void selectImgButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var openFileDialog = new Microsoft.Win32.OpenFileDialog
                {
                    Title = "Select an Image",
                    Filter = "Image Files (*.jpg; *.jpeg; *.png)|*.jpg; *.jpeg; *.png; |All files (*.*)|*.*"
                };

                if (openFileDialog.ShowDialog() == true)
                {



                    // Get the selected file path
                    string selectedImagePath = openFileDialog.FileName;

                    // Get the name of the image file
                    string imageName = Path.GetFileName(selectedImagePath);
                    string fileExtension = Path.GetExtension(selectedImagePath);

                    string unicodeString = newBook.Name;

                    // Chuyển chuỗi Unicode có dấu thành chuỗi không dấu
                    string unaccentedString = StringUtils.RemoveAccents(unicodeString);
                    unaccentedString = unaccentedString.Replace(" ", "");
                    string idFileName = newBook.ID < 10 ? "0" + newBook.ID : newBook.ID.ToString();

                    string imageFileName = $"{idFileName}{fileExtension}";



                    //MessageBox.Show("chuoi da chuyen: " + imageFileName);


                    // Get the directory where the executable is located
                    string exeDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                    // Specify the target directory (e.g., 'assets')
                    string targetDirectory = Path.Combine(exeDirectory, "assets/books/");

                    // Create the target directory if it doesn't exist
                    if (!Directory.Exists(targetDirectory))
                    {
                        Directory.CreateDirectory(targetDirectory);
                    }

                    // Construct the full path to the target image
                    string targetImagePath = Path.Combine(targetDirectory, imageFileName);

                    // Copy the selected image to the target directory: exe folder
                    File.Copy(selectedImagePath, targetImagePath, true);

                    // get current path
                    string sourceCodeDirectory = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));

                    // remove \bin, replace \
                    sourceCodeDirectory = sourceCodeDirectory.Replace("\\bin", "");
                    //MessageBox.Show("Current Path: " + sourceCodeDirectory);


                    // combine path
                    string targetOutputPath = Path.Combine(sourceCodeDirectory, "assets", "books", imageFileName);

                    //MessageBox.Show("Target Dir: " + targetOutputPath);
                    //MessageBox.Show("Selected Image Path: " + selectedImagePath);


                    File.Copy(selectedImagePath, targetOutputPath, true);
                    File.SetAttributes(targetOutputPath, FileAttributes.Normal);


                    // Get the relative path
                    string relativePath = Path.Combine("assets/books/", imageFileName);

                    // Update the UI or do whatever you need with the relative path
                    // imageControl.Source = new BitmapImage(new Uri(targetImagePath));

                    newBook.CoverImg = relativePath;




                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error selecting image: {ex.Message}");
            }
        }

        
    }
    }

