using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
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


        BindingList<CBook> _books;


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _books = new BindingList<CBook>();

            // Replace "YourQuery" with your actual SQL query to retrieve data
            string query = "SELECT * FROM Books";

            using (SqlCommand command = new SqlCommand(query, DB.Instance.Connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Create CBook instances and populate properties
                        int id = Convert.ToInt32(reader["ID"]);
                        string name = Convert.ToString(reader["Name"]);
                        string coverImg = Convert.ToString(reader["Cover_Img_Path"]);
                        string author = Convert.ToString(reader["Author"]);
                        int publishedYear = Convert.ToInt32(reader["Published_Year"]);
                        int price = Convert.ToInt32(reader["Price"]);

                        CBook book = new CBook(id, name, coverImg, author, publishedYear, price);

                        _books.Add(book);
                    }
                }
            }
        

            booksComboBox.ItemsSource = _books;
        }





    private void addButton_Click(object sender, RoutedEventArgs e)
        {

            // Mở cửa sổ AddBook (ShowDialog chờ cho đến khi cửa sổ con đóng lại)
            var screen = new AddBookWindow(_books.Count());
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
                            _books.Add(new CBook()
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
            int i = booksComboBox.SelectedIndex;
            if (i == -1)
            {
                MessageBox.Show("Please select the book you want to remove !!!");
                return;
            }
            // Lấy thông tin về sách đã chọn
            CBook selectedBook = _books[i];

            // Hiển thị hộp thoại xác nhận
            MessageBoxResult result = MessageBox.Show($"Are you sure you want to remove '{selectedBook.Name}'?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

            // Kiểm tra xem người dùng đã xác nhận xóa hay không
            if (result == MessageBoxResult.Yes)
            {
                // Nếu xác nhận xóa, thì xóa sách khỏi danh sách


                string deleteQuery = $"DELETE FROM Books WHERE ID = {_books[i].ID}";

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
                            _books.RemoveAt(i);

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
            int i = booksComboBox.SelectedIndex;
            if (i == -1)
            {
                MessageBox.Show("Please select a book to edit !!!");
                return;
            }

            var book = (CBook)booksComboBox.SelectedItem;



            // Book class has properties ID, Name, Author, PublishedYear, CoverImg, and Credits
            var backup = (CBook)book.Clone();

            var screen = new EditBookWindow(book);

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
                string query = "UPDATE Books " +
                                "SET Name = @UpdatedName, Author = @UpdatedAuthor, Cover_Img_Path = @UpdatedImagePath, Published_Year = @UpdatedPublishedYear , Price = @UpdatedPrice " +
                                "WHERE Id = @BookId";

                using (SqlCommand command = new SqlCommand(query, DB.Instance.Connection))
                {
                    command.Parameters.AddWithValue("@UpdatedName", screen.EditedBook.Name);
                    command.Parameters.AddWithValue("@UpdatedAuthor", screen.EditedBook.Author);
                    command.Parameters.AddWithValue("@UpdatedPrice", screen.EditedBook.Price);
                    command.Parameters.AddWithValue("@UpdatedPublishedYear", screen.EditedBook.PublishedYear);


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



        private void booksComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
