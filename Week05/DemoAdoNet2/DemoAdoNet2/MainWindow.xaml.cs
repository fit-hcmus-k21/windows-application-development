using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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

namespace DemoAdoNet2
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

        BindingList<Category> _categories;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadAllCategories();
        }

        private void LoadAllCategories()
        {
            var sql = "select * from Category";
            var command = new SqlCommand(sql, DB.Instance.Connection);
            //command.Parameters.Add("@id", System.Data.SqlDbType.Int)
            //    .Value = 1;
            var reader = command.ExecuteReader();
            _categories = new BindingList<Category>();

            while (reader.Read())
            {
                int id = (int)reader["ID"];
                string name = (string)reader["Category_Name"];

                var category = new Category()
                {
                    Id = id,
                    Name = name
                };
                _categories.Add(category);

                Debug.WriteLine($"{id} - {name}");
            }
            reader.Close();

            categoriesComboBox.ItemsSource = _categories;
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            var newCategory = new Category()
            {
                Name = "Mousepad"
            };

            string sql = """
                insert into Category(Category_Name) values(@Name);
                select ident_current('Category');
             """;
            var command = new SqlCommand(sql, DB.Instance.Connection);
            command.Parameters.Add("@Name", System.Data.SqlDbType.Text)
                .Value = newCategory.Name;

            int id = (int) ((decimal)command.ExecuteScalar());

            if (id > 0)
            {
                MessageBox.Show($"Insert successfully new category: {newCategory.Name}");
                //LoadAllCategories();
                newCategory.Id = id;
                _categories.Add(newCategory);
            } else
            {
                MessageBox.Show("Insert failed");
            }
        }
    }
}
