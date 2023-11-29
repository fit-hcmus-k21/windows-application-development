using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            _books= new BindingList<CBook>()
            {
                new CBook() { ID = "001",  Name="Đắc Nhân Tâm",     CoverImg="assets/books/01.DacNhanTam.jpg", Author="Dale Carnegie", PublishedYear=2020},
                new CBook() { ID = "002",  Name="Đánh Thức Con Người Bên Trong Bạn", CoverImg="assets/books/02.DanhThucConNguoiBenTrongBan.jpg", Author="Tony Robbins", PublishedYear=2019},
                new CBook() { ID = "003",  Name="How Psychology Works",  CoverImg="assets/books/03.HowPsychologyWorks.jpg", Author="Jo Hemmings", PublishedYear=2020},
                new CBook() { ID = "004",  Name="Mindset",      CoverImg="assets/books/04.Mindset.jpg", Author="Carol S.Dweck", PublishedYear=2018},
                new CBook() { ID = "005",  Name="Object Oriented Programming",   CoverImg="assets/books/05.OOP.jpg", Author="HCMUS", PublishedYear=2010},
                new CBook() { ID = "006",  Name="Tâm Lý Học Đời Sống",     CoverImg="assets/books/06.TamLyHocDoiSong.jpg", Author="Sigmund Freud", PublishedYear=2016},
                new CBook() { ID = "007",  Name="Tâm Lý Học Nỗi Đau", CoverImg="assets/books/07.TamLyHocNoiDau.jpg", Author="Patrick Wall", PublishedYear=2018},
                new CBook() { ID = "008",  Name="Tâm Lý Học Tội Phạm",  CoverImg="assets/books/08.TamLyHocToiPham.jpg", Author="Hans Gross", PublishedYear=2017},
                new CBook() { ID = "009",  Name="Luyện Thi Toeic 850",      CoverImg="assets/books/09.TOEIC.jpg", Author="Trung Tam Anh Ngu", PublishedYear=2021},
                new CBook() { ID = "010",  Name="Tư Duy Phản Biện",   CoverImg="assets/books/10.TuDuyPhanBien.jpg", Author="Richard Paul and Linda Elder", PublishedYear=2022},
                new CBook() { ID = "011",  Name="Why We Sleep ?",     CoverImg="assets/books/11.WhyWeSleep.jpg", Author="Matthew Walker", PublishedYear=2020}           };

            booksComboBox.ItemsSource = _books;
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            _books.Add(new CBook()
            {
                ID = "003",
                Name = "How Psychology Works",
                CoverImg = "assets/books/03.HowPsychologyWorks.jpg",
                Author = "Jo Hemmings",
                PublishedYear = 2020
            });
            MessageBox.Show("added");
        }

        private void removeButton_Click(object sender, RoutedEventArgs e)
        {
            int i = booksComboBox.SelectedIndex;
            _books.RemoveAt(i);
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            int i = booksComboBox.SelectedIndex;
            _books[i].ID = "011";
            _books[i].CoverImg = "assets/books/11.WhyWeSleep.jpg";
            _books[i].Name = "Why We Sleep ?";
            _books[i].Author = "Matthew Walker";
            _books[i].PublishedYear = 2020;

        }

        private void deleteMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var book = (CBook)booksComboBox.SelectedItem;
            _books.Remove(book);
        }

        CBook _backup;


        private void editMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var book = (CBook)booksComboBox.SelectedItem;

            // Book class has properties ID, Name, Author, PublishedYear, CoverImg, and Credits
            var backup = (CBook)book.Clone();

            var screen = new EditBookWindow(book);

            //  EditBookWindow has an event named BookEdited
            screen.BookEdited += (sender, editedBook) =>
            {
                // Update properties based on your Book class
                book.Name = editedBook.Name;
                book.Author = editedBook.Author;
                book.PublishedYear = editedBook.PublishedYear;
            };

            if (screen.ShowDialog() == true)
            {
                //  have implemented a CopyProperties method in your Book class
                screen.EditedBook.CopyProperties(book);
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
