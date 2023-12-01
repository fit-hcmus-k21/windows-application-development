using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.WebSockets;
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

namespace DemoValidation
{
    /// <summary>
    /// Interaction logic for EFDemoWindow.xaml
    /// </summary>
    public partial class EFDemoWindow : Window
    {
        public EFDemoWindow()
        {
            InitializeComponent();
        }


        TestContext _db;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _db = new TestContext();

            if (_db.Database.CanConnect())
            {
                Title = "Database is ready!";
            } else
            {
                Title = "Cannot connect to database";
            }
        }

        BindingList<Category> _categories;
        private void loadButton_Click(object sender, RoutedEventArgs e)
        {
            _categories = new BindingList<Category>(_db.Categories.ToList());
            categoriesListBox.ItemsSource = _categories;
        }

        private void insertButton_Click(object sender, RoutedEventArgs e)
        {
            var category = new Category()
            {
                Name = "All-In-One PC"
            };
            _db.Categories.Add(category);
            _db.SaveChanges();

            _categories.Add(category);
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            var id = ((Category) categoriesListBox.SelectedItem).Id;
            var category = _db.Categories.FirstOrDefault(cat => cat.Id == id);
            category!.Name = "Updated";
            _db.SaveChanges();

            category = _categories.FirstOrDefault(cat => cat.Id == id);
            category!.Name = "Updated";
        }
    }
}
