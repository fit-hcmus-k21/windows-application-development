using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Common;
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
using System.Windows.Shapes;

namespace DataBindingOneObject
{
    /// <summary>
    /// Interaction logic for ListCBooks.xaml
    /// </summary>
    public partial class ListBooksWindow : Window
    {
        public ListBooksWindow()
        {
            InitializeComponent();
        }


        BindingList<CBook> _products;
        BindingList<Category> _categories;

        // declare variables
        int _rowPerPage = 10;
        int _totalPages = -1;
        int _totalItems = -1;
        int _currentPage = 1;


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            int numberItemsPerPage = int.Parse(ConfigurationManager.AppSettings["ItemsPerPage"]);
            if (numberItemsPerPage > 0)
            {
                _rowPerPage = numberItemsPerPage;
            }
            else
            {
                MessageBox.Show("Cannot read history ");
            }

            LoadAllProducts();
            LoadAllCategories();



        }



        private void LoadAllProducts()
        {
            var sql = @"
                select *, count(*) over() as Total from Product
                where LOWER(CONVERT(VARCHAR(100), Name)) LIKE LOWER(CONVERT(VARCHAR(100), @Keyword))
                        OR LOWER(CONVERT(VARCHAR(100), Author)) LIKE LOWER(CONVERT(VARCHAR(100), @Keyword))
                order by ID
                offset @Skip rows fetch next @Take rows only
                ";
            var command = new SqlCommand(sql, DB.Instance.Connection);
            command.Parameters.Add("@Skip", SqlDbType.Int).Value = (_currentPage - 1) * _rowPerPage;
            command.Parameters.Add("@Take", SqlDbType.Int).Value = _rowPerPage;
            var keyword = keywordTextBox.Text;
            command.Parameters.Add("@Keyword", SqlDbType.Text).Value = $"%{keyword}%";

            int count = -1;
            _products = new BindingList<CBook>();

            using (var reader = command.ExecuteReader())
            {
                   while(reader.Read())
                {
                    // Create CBook instances and populate properties
                    int id = (int)reader["ID"];
                    string name = (string)reader["Name"];
                    string coverImg = (string)reader["Cover_Img_Path"];
                    string author = (string)reader["Author"];
                    int publishedYear = (int)reader["Published_Year"];
                    int price = (int)reader["Price"];

                    int categoryId = 0; // default

                    if (reader["Category_ID"] != DBNull.Value)
                    {
                        categoryId = (int)reader["Category_ID"];
                    }
                    

                    CBook book = new CBook(id, name, coverImg, author, publishedYear, price, categoryId);

                    _products.Add(book);

                    count = (int)reader["Total"];
                }
            }

            productsListView.ItemsSource = _products;

            if (count != _totalItems)
            {
                _totalItems = count;
                _totalPages = (_totalItems / _rowPerPage) +  (((_totalItems % _rowPerPage) == 0) ? 0 : 1);

                // tạo thông tin phân trang
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

        private void LoadAllCategories()
        {
            var sql = @"
                select * from Category
              
                order by ID
                ";
            var command = new SqlCommand(sql, DB.Instance.Connection);
            
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

            }
            reader.Close();

            // add all option for filter
            _categories.Add(new Category()
            {
                Id = -1,
                Name = "All"
            });

            categoriesComboBox.ItemsSource = _categories;
            categoriesComboBox.SelectedIndex = _categories.Count -1;
        }




        private void addButton_Click(object sender, RoutedEventArgs e)
        {

            // Mở cửa sổ AddBook (ShowDialog chờ cho đến khi cửa sổ con đóng lại)
            var screen = new AddBookWindow(_products[^1].ID, _categories.ToList());
            bool? result = screen.ShowDialog();

            // Kiểm tra kết quả trả về sau khi cửa sổ con đóng
            if (result == true)
            {


                // Retrieve data from AddBook window
                string name = screen.newBook.Name;
                string author = screen.newBook.Author;
                string coverImg = screen.newBook.CoverImg;
                int publishedYear = screen.newBook.PublishedYear;
                int price = screen.newBook.Price;

                // add Books table in database
                // Insert new record into Books table
                string insertQuery = "INSERT INTO Books (Name, Author, Cover_Img_Path, Published_Year, Price) " +
                                     "VALUES (@name, @author, @cover_img, @published_year, @price);";

                using (SqlCommand insertCommand = new SqlCommand(insertQuery, DB.Instance.Connection))
                {
                    // Set parameter values
                    insertCommand.Parameters.AddWithValue("@name", name);
                    insertCommand.Parameters.AddWithValue("@author", author);
                    insertCommand.Parameters.AddWithValue("@cover_img", coverImg);
                    insertCommand.Parameters.AddWithValue("@published_year", publishedYear);
                    insertCommand.Parameters.AddWithValue("@price", price);

                    // Execute the query
                    int rowsAffected = insertCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        // The insertion was successful
                        MessageBox.Show("Book added to the database successfully!");

                        // Thực thi truy vấn và lấy giá trị identity vừa chèn
                        int maxId = -1;
                        string query = "SELECT MAX(ID) from Books;";
                        using (SqlCommand command = new SqlCommand(query, DB.Instance.Connection))
                        {
                            maxId = Convert.ToInt32(command.ExecuteScalar());

                        }
                            _products.Add(new CBook()
                        {
                            ID = maxId,
                            Name = name,
                            Author = author,
                            CoverImg = coverImg,
                            PublishedYear = publishedYear,
                            Price = price,
                        }

                            ) ; 
                    }
                    else
                    {
                        // The insertion failed
                        MessageBox.Show("Failed to add book to the database.");
                    }


                }

            }

        }

        private void removeButton_Click(object sender, RoutedEventArgs e)
        {
            int i = productsListView.SelectedIndex;
            if (i == -1)
            {
                MessageBox.Show("Please select the book you want to remove !!!");
                return;
            }
            // Lấy thông tin về sách đã chọn
            CBook selectedBook = _products[i];

            // Hiển thị hộp thoại xác nhận
            MessageBoxResult result = MessageBox.Show($"Are you sure you want to remove '{selectedBook.Name}'?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

            // Kiểm tra xem người dùng đã xác nhận xóa hay không
            if (result == MessageBoxResult.Yes)
            {
                // Nếu xác nhận xóa, thì xóa sách khỏi danh sách


                string deleteQuery = $"DELETE FROM Books WHERE ID = {_products[i].ID}";

                using (SqlCommand command = new SqlCommand(deleteQuery, DB.Instance.Connection))
                {
                    // exec the query
                        try
                        {
                            

                            // Thực thi truy vấn DELETE
                            int rowsAffected = command.ExecuteNonQuery();

                            // Kiểm tra xem có bao nhiêu dòng bị ảnh hưởng (nên là 1 nếu xóa thành công)
                            if (rowsAffected > 0)
                            {
                            // MessageBox.Show($"Deleted {rowsAffected} row(s) successfully.");
                            _products.RemoveAt(i);

                        }
                        else
                            {
                                MessageBox.Show("No rows were deleted. The specified ID might not exist.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error deleting row: {ex.Message}");
                        }
                      

                }

                MessageBox.Show("Book removed successfully!");
            }
            else
            {
                // Nếu không, không thực hiện hành động xóa
                MessageBox.Show("Book removal canceled.");
            }

        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            editMenuItem_Click(sender, e);

        }

        private void deleteMenuItem_Click(object sender, RoutedEventArgs e)
        {
            removeButton_Click(sender, e);
        }

        CBook _backup;


        private void editMenuItem_Click(object sender, RoutedEventArgs e)
        {
            int i = productsListView.SelectedIndex;
            if (i == -1)
            {
                MessageBox.Show("Please select a book to edit !!!");
                return;
            }

            var book = (CBook)productsListView.SelectedItem;



            // Book class has properties ID, Name, Author, PublishedYear, CoverImg, and Credits
            var backup = (CBook)book.Clone();

            var screen = new EditBookWindow(book, _categories);

            //  EditBookWindow has an event named BookEdited
            //screen.BookEdited += (sender, editedBook) =>
            //{
            //    // Update properties based on your Book class
            //    book.Name = editedBook.Name;
            //    book.Author = editedBook.Author;
            //    book.PublishedYear = editedBook.PublishedYear;
            //    book.Price = editedBook.Price;
            //    book.CoverImg = editedBook.CoverImg;
            //};

            if (screen.ShowDialog() == true)
            {
                //  have implemented a CopyProperties method in your Book class
                screen.EditedBook.CopyProperties(book);

                // update Books table in database
                string query = "UPDATE Product " +
                                "SET Name = @UpdatedName, Author = @UpdatedAuthor, Cover_Img_Path = @UpdatedImagePath, Published_Year = @UpdatedPublishedYear , Price = @UpdatedPrice, Category_ID = @UpdatedCategoryId " +
                                "WHERE Id = @BookId";

                using (SqlCommand command = new SqlCommand(query, DB.Instance.Connection))
                {
                    command.Parameters.AddWithValue("@UpdatedName", screen.EditedBook.Name);
                    command.Parameters.AddWithValue("@UpdatedAuthor", screen.EditedBook.Author);
                    command.Parameters.AddWithValue("@UpdatedPrice", screen.EditedBook.Price);
                    command.Parameters.AddWithValue("@UpdatedPublishedYear", screen.EditedBook.PublishedYear);
                    command.Parameters.AddWithValue("@UpdatedCategoryId", screen.EditedBook.CategoryId);



                    command.Parameters.AddWithValue("@UpdatedImagePath", screen.EditedBook.CoverImg);
                    command.Parameters.AddWithValue("@BookId", screen.EditedBook.ID); // Replace with the actual Id of the book

                    command.ExecuteNonQuery();
                }

                MessageBox.Show("Updated in database !");
            }
            else
            {
                //  implemented a CopyProperties method in your Book class
                backup.CopyProperties(book);
            }
        }



        private void productsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

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

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            LoadAllProducts();
        }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            if (pagingComboBox.SelectedIndex < _totalPages - 1)
            {
                pagingComboBox.SelectedIndex++;
            }
        }

        private void categoriesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //MessageBox.Show("Category choose: " + categoriesComboBox.SelectedIndex );
            LoadAllProducts();

        }

        private void setItemsPerPage_Click(object sender, RoutedEventArgs e)
        {
            int num = int.Parse(setItemsPerPageTextBox.Text);
            if (num > 0)
            {
                _rowPerPage = num;

                // save to settings
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["ItemsPerPage"].Value = num.ToString();
               
                config.Save(ConfigurationSaveMode.Minimal);

                ConfigurationManager.RefreshSection("appSettings");


                LoadAllProducts();

                _totalPages = (_totalItems / _rowPerPage) + (((_totalItems % _rowPerPage) == 0) ? 0 : 1);

                // tạo thông tin phân trang
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
            } else
            {
                MessageBox.Show("Number of items per page must > 0 !!!");
            }
        }
    }
}
