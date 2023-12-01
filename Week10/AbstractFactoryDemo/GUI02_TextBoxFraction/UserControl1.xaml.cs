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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Entity;
using ThreeLayerContract;

namespace GUI02_TextBoxFraction
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        class StringToFractionConverter
        {
            const string SEPERATOR = "/";

            public static Fraction ToFraction(string s)
            {
                var parts = s.Split(new string[] { SEPERATOR }, StringSplitOptions.None);
                var num = int.Parse(parts[0]);
                var den = int.Parse(parts[1]);
                var result = new Fraction() { Numerator = num, Denominator = den };

                return result;
            }    
               
            public static string ToString(Fraction f)
            {
                return string.Format("{0}/{1}", f.Numerator, f.Denominator);
            }
        }

        IBus _bus;
        Fraction _result = null;
        public UserControl1(IBus bus)
        {
            _bus = bus;
            InitializeComponent();
        }


        private void btnCalculateSum_Click(object sender, RoutedEventArgs e)
        {
            Fraction a = StringToFractionConverter.ToFraction(txtFraction1.Text);
            Fraction b = StringToFractionConverter.ToFraction(txtFraction2.Text);

            _result = _bus.Add(a, b);
            txtResult.Text = StringToFractionConverter.ToString(_result);
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            _bus.Save(_result, "data");
            MessageBox.Show("Đã lưu thành công kết quả tính toán!");
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var list = _bus.GetAll("data");
            fractionsCombobox.ItemsSource = list;
        }
    }
}
