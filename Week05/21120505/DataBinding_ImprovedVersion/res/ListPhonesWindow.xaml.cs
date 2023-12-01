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
    /// Interaction logic for ListPhones.xaml
    /// </summary>
    public partial class ListPhonesWindow : Window
    {
        public ListPhonesWindow()
        {
            InitializeComponent();
        }

        BindingList<CPhone> _phones;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _phones = new BindingList<CPhone>()
            {
                new CPhone() {ID = "001", Name = "Xiaomi Redmi Note 11", Manufacturer = "Xiaomi Co .Ltd", Price = 4999000, Image = "assets/phones/01.XiaomiRedmiNote11.jpg"},
                new CPhone() {ID = "002", Name = "Xiaomi Redmi Note 11T Pro", Manufacturer = "Xiaomi Co .Ltd", Price = 5999000, Image = "assets/phones/02.XiaomiRedmiNote11TPro.jpg"},
                new CPhone() {ID = "003", Name = "Oppo A9X", Manufacturer = "Oppo Co .Ltd", Price = 6999000, Image = "assets/phones/03.OppoA9X.jpg"},
                new CPhone() {ID = "004", Name = "Oppo F1", Manufacturer = "Oppo Co .Ltd", Price = 7999000, Image = "assets/phones/04.OppoF1.jpg"},
                new CPhone() {ID = "005", Name = "IPhone 15", Manufacturer = "IP Co .Ltd", Price = 8999000, Image = "assets/phones/05.Iphone15.jpg"},
                new CPhone() {ID = "006", Name = "IPhone 11 Pro", Manufacturer = "IP Co .Ltd", Price = 7499000, Image = "assets/phones/06.Iphone11Pro.jpg"},
                new CPhone() {ID = "007", Name = "Samsung Galaxy S22 Ultra 5G", Manufacturer = "Samsung Co .Ltd", Price = 6499000, Image = "assets/phones/07.SamsungGalaxyS22Ultra5G.jpg"},
                new CPhone() {ID = "008", Name = "Samsung S20 ", Manufacturer = "Samsung Co .Ltd", Price = 5499000, Image = "assets/phones/08.SamsungS20.jpg"},
                new CPhone() {ID = "009", Name = "Google Pixel 4", Manufacturer = "Google Co .Ltd", Price = 4499000, Image = "assets/phones/09.GooglePixel4.jpg"},
                new CPhone() {ID = "010", Name = "Huawei PSmart S", Manufacturer = "Huawei Co .Ltd", Price = 3999000, Image = "assets/phones/10.HuaweiPSmartS.jpg"},

            };

            phonesComboBox.ItemsSource = _phones;
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            _phones.Add(new CPhone()
            {
                ID = "022",
                Name = "Xiaomi Redmi Note 11",
                Manufacturer = "Xiaomi Co. Ltd",
                Image = "assets/phones/01.XiaomiRedmiNote11.jpg",
                Price = 4999000
            });
            MessageBox.Show("added");
        }

        private void removeButton_Click(object sender, RoutedEventArgs e)
        {
            int i = phonesComboBox.SelectedIndex;
            _phones.RemoveAt(i);
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            int i = phonesComboBox.SelectedIndex;
            _phones[i].ID = "019";
            _phones[i].Image = "assets/phones/03.OppoA9X.jpg";
            _phones[i].Name = "Oppo A9X";
            _phones[i].Manufacturer = "BBK Corp";
            _phones[i].Price = 5999000;
        }

        private void deleteMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var phone = (CPhone)phonesComboBox.SelectedItem;
            _phones.Remove(phone);
        }

        CPhone _backup;

        private void editMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var phone = (CPhone)phonesComboBox.SelectedItem;

            // CPhone class has properties ID, Name, Manufacturer, Price, and CoverImg
            var backup = (CPhone)phone.Clone();

            var screen = new EditPhoneWindow(phone);

            // EditPhoneWindow has an event named PhoneEdited
            screen.PhoneEdited += (sender, editedPhone) =>
            {
                // Update properties based on your CPhone class
                phone.Name = editedPhone.Name;
                phone.Manufacturer = editedPhone.Manufacturer;
                phone.Price = editedPhone.Price;
            };

            if (screen.ShowDialog() == true)
            {
                // Implement a CopyProperties method in your CPhone class
                screen.EditedPhone.CopyProperties(phone);
            }
            else
            {
                // Implement a CopyProperties method in your CPhone class
                backup.CopyProperties(phone);
            }
        }



        private void phonesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
