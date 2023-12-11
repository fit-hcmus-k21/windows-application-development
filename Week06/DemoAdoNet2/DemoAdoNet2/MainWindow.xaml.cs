using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        BindingList<Product> _products;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //LoadCurrentPageCategories();


            LoadAllProducts();
        }

        int _rowsPerPage = 10;
        int _totalPages = -1;
        int _totalItems = -1;
        int _currentPage = 1;
        private void LoadAllProducts()
        {
            var sql = """
                select *, count(*) over() as Total from Product
                where Product_Name like @Keyword
                order by ID
                offset @Skip rows fetch next @Take rows only
                """;
            var command = new SqlCommand(sql, DB.Instance.Connection);
            command.Parameters.Add("@Skip", SqlDbType.Int)
                .Value = (_currentPage - 1) * _rowsPerPage;
            command.Parameters.Add("@Take", SqlDbType.Int)
                .Value = _rowsPerPage;
            var keyword = keywordTextBox.Text;
            command.Parameters.Add("@Keyword", SqlDbType.Text)
                .Value = $"%{keyword}%";

            int count = -1;
            _products = new BindingList<Product>();

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var id = (int)reader["ID"];
                    var name = (string)reader["Product_Name"];
                    var price = (int)reader["Price"];

                    var product = new Product()
                    {
                        Id = id,
                        Name = name,
                        Price = price,
                    };
                    _products.Add(product);

                    count = (int)reader["Total"];

                }
            }

            productsListView.ItemsSource = _products;

            if (count != _totalItems)
            {
                _totalItems = count;
                _totalPages = (_totalItems / _rowsPerPage) +
                    (((_totalItems % _rowsPerPage) == 0) ? 0 : 1);

                // Tạo thông tin phân trang cho combobox
                var pageInfos = new List<object>();

                for (int i = 1; i <= _totalPages; i++)
                {
                    pageInfos.Add(new
                    {
                        Page = i,
                        Total = _totalPages
                    });
                };

                pagingComboBox.ItemsSource = pageInfos;
                pagingComboBox.SelectedIndex = 0;
            }

            Title = $"Displaying {_products.Count} / {_totalItems}";

        }



        private void LoadCurrentPageCategories()
        {
            var sql = """
                select *, count(*) over() as Total from Product
                
                order by ID
                offset @Skip rows fetch next @Take rows only
                """;
            var command = new SqlCommand(sql, DB.Instance.Connection);
            //command.Parameters.Add("@id", System.Data.SqlDbType.Int)
            //    .Value = 1;
            var reader = command.ExecuteReader();
            _categories = new BindingList<Category>();

            while (reader.Read())
            {
                int id = (int)reader["ID"];
                string name = (string)reader["Name"];

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

            int id = (int)((decimal)command.ExecuteScalar());

            if (id > 0)
            {
                MessageBox.Show($"Insert successfully new category: {newCategory.Name}");
                //LoadAllCategories();
                newCategory.Id = id;
                _categories.Add(newCategory);
            }
            else
            {
                MessageBox.Show("Insert failed");
            }
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            var category = (Category)categoriesComboBox.SelectedItem;
            if (category != null)
            {
                string sql = "delete from Category where ID=@ID";
                var command = new SqlCommand(sql, DB.Instance.Connection);
                command.Parameters.Add("@ID", System.Data.SqlDbType.Int)
                    .Value = category.Id;

                int count = command.ExecuteNonQuery();

                if (count > 0)
                {
                    MessageBox.Show($"Category {category.Name} is deleted!");
                    _categories.Remove(category);
                }
            }
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            //var category = (Category)categoriesComboBox.SelectedItem;
            //category.Name = "Mini PC";
            var product = new Product()
            {
                Id = 5,
                Name = "Macbook",
                Price = 20000000,
                Description = "Ultra portable laptop"
            };

            var editedProduct = new Product()
            {
                Id = 5,
                Name = "Geek A50",
                Price = 20000000,
                Description = "Mini laptop"
            };

            var columns = new List<string>();
            var names = new List<string>();
            var types = new List<SqlDbType>();
            var values = new List<object>();

            if (product.Id != editedProduct.Id)
            {
                columns.Add("ID");
                names.Add("@ID");
                types.Add(SqlDbType.Int);
                values.Add(product.Id);
            }
            if (product.Name != editedProduct.Name)
            {
                columns.Add("Name");
                names.Add("@Name");
                types.Add(SqlDbType.Text);
                values.Add(product.Name);
            }
            if (product.Description != editedProduct.Description)
            {
                columns.Add("Description");
                names.Add("@Description");
                types.Add(SqlDbType.Text);
                values.Add(product.Description);
            }
            if (product.Price != editedProduct.Price)
            {
                columns.Add("Price");
                names.Add("@Price");
                types.Add(SqlDbType.Int);
                values.Add(product.Price);
            }

            string sql = "update Product set ";
            for (int i = 0; i < columns.Count; i++)
            {
                sql += $"{columns[i]}={names[i]} ";
                if (i != columns.Count - 1)
                {
                    sql += ",";
                }
                sql += " ";
            }

            sql += " where ID=@ID";
            var command = new SqlCommand(sql, DB.Instance.Connection);

            for (int i = 0; i < values.Count; i++)
            {
                command.Parameters.Add(names[i], types[i])
                    .Value = values[i];
            }

            command.Parameters.Add("@ID", SqlDbType.Int)
                .Value = product.Id;

            int count = command.ExecuteNonQuery();

            if (count > 0)
            {
                MessageBox.Show("Update successfully!");

                editedProduct.CopyProperties(product);
            }
        }

        private void pagingComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dynamic info = pagingComboBox.SelectedItem;
            if (info != null)
            {
                if (info?.Page != _currentPage)
                {
                    _currentPage = info?.Page;
                    LoadAllProducts();
                }
            }
        }

        private void previousButton_Click(object sender, RoutedEventArgs e)
        {
            if (pagingComboBox.SelectedIndex > 0)
            {
                pagingComboBox.SelectedIndex--;
            }
        }

        private void keywordTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //LoadAllProducts();
        }

        private void keywordTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                LoadAllProducts();
            }
        }
    }
}