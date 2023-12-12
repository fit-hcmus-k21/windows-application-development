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
        bool _hasCategoryFilter= false;
        bool _hasPriceFilter = false;
        bool _hasPublishedYearFilter = false;


        public class Year
        {
            public string SelectedYear { get; set; }
        }

        BindingList<Year> _publishedYears;



        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            int numberItemsPerPage = int.Parse(ConfigurationManager.AppSettings["ItemsPerPage"]);
            if (numberItemsPerPage > 0)
            {
                _rowPerPage = numberItemsPerPage;
            }
            
            LoadAllProducts();
            LoadAllCategories();
            LoadAllPublishedYears();

            sortingComboBox.SelectedIndex = 0;



        }


        int categoryFilter = -1;
        int yearFilter = -1;
        int minPrice = -1;
        int maxPrice = -1;

        private void LoadAllProducts()
        {
            // filter category
            if (_hasCategoryFilter)
            {
                categoryFilter = _categories[categoriesComboBox.SelectedIndex].Id;
                //MessageBox.Show("Filter " + categoryFilter);
            }

            if (_hasPublishedYearFilter)
            {
                yearFilter = int.Parse(_publishedYears[publishedYearComboBox.SelectedIndex].SelectedYear);
            }

            if (_hasPriceFilter)
            {
                minPrice = int.Parse(minPriceTextBox.Text);
                maxPrice = int.Parse(maxPriceTextBox.Text); 
            }


            var sql = @"
                select *, count(*) over() as Total from Product
                where (LOWER(CONVERT(VARCHAR(100), Name)) LIKE LOWER(CONVERT(VARCHAR(100), @Keyword))
                        OR LOWER(CONVERT(VARCHAR(100), Author)) LIKE LOWER(CONVERT(VARCHAR(100), @Keyword))) 
                " 
                + (_hasCategoryFilter ? " AND Category_ID = @CategoryId " : " ")
                + (_hasPublishedYearFilter ? " AND Published_Year = @PublishedYear " : " ")
                + (_hasPriceFilter ? " AND (Price BETWEEN @MinPrice AND @MaxPrice) " : " ") 
                + _sortingCriteriaQuery
                +
                @"
                offset @Skip rows fetch next @Take rows only
                ";
            // MessageBox.Show("Command: " + sql);
            var command = new SqlCommand(sql, DB.Instance.Connection);
            command.Parameters.Add("@Skip", SqlDbType.Int).Value = (_currentPage - 1) * _rowPerPage;
            command.Parameters.Add("@Take", SqlDbType.Int).Value = _rowPerPage;
            var keyword = keywordTextBox.Text;
            command.Parameters.Add("@Keyword", SqlDbType.Text).Value = $"%{keyword}%";
            if (_hasCategoryFilter )
            {
                command.Parameters.Add("@CategoryId", SqlDbType.Int).Value = categoryFilter;
            }
            if ( _hasPublishedYearFilter )
            {
                command.Parameters.Add("@PublishedYear", SqlDbType.Int).Value = yearFilter;
            }
            if (_hasPriceFilter)
            {
                command.Parameters.Add("@MinPrice", SqlDbType.Int).Value = minPrice;
                command.Parameters.Add("@MaxPrice", SqlDbType.Int).Value = maxPrice;

            }

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
                Id = _categories.Count,
                Name = "All"
            });

            categoriesComboBox.ItemsSource = _categories;
            categoriesComboBox.SelectedIndex = _categories.Count -1;
        }

        private void LoadAllPublishedYears()
        {
            var sql = @"
                select distinct Published_Year from Product
                order by Published_Year ASC
                ";
            var command = new SqlCommand(sql, DB.Instance.Connection);

            var reader = command.ExecuteReader();
            _publishedYears = new BindingList<Year> {  };

            while (reader.Read())
            {
                int year = (int)reader["Published_Year"];

                _publishedYears.Add(new Year()
                {
                    SelectedYear = year.ToString(),
                });

            }
            reader.Close();


            _publishedYears.Add(new Year() { SelectedYear = "All"});
            publishedYearComboBox.ItemsSource = _publishedYears;
            publishedYearComboBox.SelectedIndex = _publishedYears.Count -1;

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

                        // load published Years
                        LoadAllPublishedYears();
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
            int id = categoriesComboBox.SelectedIndex;
            // MessageBox.Show("Category choose: " + _categories[id].Name );
            if ( ! _categories[id].Name.Equals("All")) {
                _hasCategoryFilter = true;
                // MessageBox.Show("Has Filter !");
            } else
            {
                _hasCategoryFilter = false;
            }
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

        private void publishedYearComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (publishedYearComboBox.SelectedIndex == _publishedYears.Count - 1) {
                _hasPublishedYearFilter = false;
            } else
            {
                _hasPublishedYearFilter = true;
            }
            LoadAllProducts();
        }

        private void ApplyFilter_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateMinMaxPrices())
            {
                _hasPriceFilter = true;
            } else
            {
                _hasPriceFilter = false;
            }

            LoadAllProducts();

        }

        private Boolean ValidateMinMaxPrices()
        {
            // Validation for minPriceTextBox
            if (!int.TryParse(minPriceTextBox.Text, out int minPrice))
            {
                MessageBox.Show("Please enter a valid number for Min Price.");
                minPriceTextBox.Focus();
                return false;
            }

            // Validation for maxPriceTextBox
            if (!int.TryParse(maxPriceTextBox.Text, out int maxPrice))
            {
                MessageBox.Show("Please enter a valid number for Max Price.");
                maxPriceTextBox.Focus();
                return false;
            }

            // Check if minPrice is less than maxPrice
            if (minPrice > maxPrice)
            {
                MessageBox.Show("Min Price should be less than or equal to Max Price.");
                minPriceTextBox.Focus();
                return false;
            }

            if (minPrice < 0 || maxPrice < 0)
            {
                MessageBox.Show("Price must be > 0.");
                minPriceTextBox.Focus();
                return false;
            }

            // ...
            return true;
        }

        private void SortingComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Get the selected item from the ComboBox
            ComboBoxItem selectedItem = (ComboBoxItem)sortingComboBox.SelectedItem;

            // Get the Tag value, which contains the sorting criteria
            string sortingCriteria = selectedItem?.Tag?.ToString();

            // Call a method to apply sorting based on the selected criteria
            ApplySorting(sortingCriteria);

            LoadAllProducts();
        }

        int _sortingCriteria = 0;   // not used after apply _sortingCriteriaQuery
        string _sortingCriteriaQuery = " ORDER BY ID ";
        public enum SortingCriteria
        {
            Default,         // Default sorting (by ID)
            Alphabetical,    // Sort by name alphabetically
            PriceAscending,  // Sort by price ascending
            PriceDescending, // Sort by price descending
            NewestFirst,     // Sort by newest first
            OldestFirst      // Sort by oldest first
        }


        private void ApplySorting(string sortingCriteria)
        {
            switch (sortingCriteria)
            {
                case "Name":
                    // Sort by name alphabetically
                    _sortingCriteria = (int) SortingCriteria.Alphabetical;
                    _sortingCriteriaQuery = " ORDER BY Name ASC ";
                    
                    break;

                case "PriceAsc":
                    // Sort by price ascending
                    _sortingCriteria = (int)SortingCriteria.PriceAscending;
                    _sortingCriteriaQuery = " ORDER BY Price ASC ";


                    break;

                case "PriceDesc":
                    // Sort by price descending
                    _sortingCriteria = (int)SortingCriteria.PriceDescending;
                    _sortingCriteriaQuery = " ORDER BY Price DESC ";


                    break;

                case "NewestFirst":
                    // Sort by newest first
                    _sortingCriteria = (int)SortingCriteria.NewestFirst;
                    _sortingCriteriaQuery = " ORDER BY Published_Year DESC ";


                    break;

                case "OldestFirst":
                    // Sort by oldest first
                    _sortingCriteria = (int)SortingCriteria.OldestFirst;
                    _sortingCriteriaQuery = " ORDER BY Published_Year ASC ";


                    break;

                default:
                    // Default sorting by ID
                    _sortingCriteria = (int)SortingCriteria.Default;
                    _sortingCriteriaQuery = " ORDER BY ID ";


                    break;
            }

            // Update data source or refresh UI here with the sorted data
            // ...
        }

        private void RemoveApplyFilter_Click(object sender, RoutedEventArgs e)
        {
            _hasPriceFilter = false;
            minPriceTextBox.Text = "Min Price";
            maxPriceTextBox.Text = "Max Price";

            LoadAllProducts();
        }
    }
}
