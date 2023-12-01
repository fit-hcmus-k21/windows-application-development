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
using ThreeLayerContract;
using Entity;

namespace GUINamespace
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        IBus _bus;
        Fraction _result = null;

        public UserControl1(IBus bus)
        {
            _bus = bus;
            InitializeComponent();
        }

        private void btnCalculateSum_Click(object sender, RoutedEventArgs e)
        {
            int num1 = int.Parse(txtFraction1Numerator.Text);
            int den1 = int.Parse(txtFraction1Denominator.Text);

            int num2 = int.Parse(txtFraction2Numerator.Text);
            int den2 = int.Parse(txtFraction2Denominator.Text);

            Fraction frac1 = new Fraction() { Numerator = num1, Denominator = den1 };
            Fraction frac2 = new Fraction() { Numerator = num2, Denominator = den2 };

            _result = _bus.Add(frac1, frac2);

            txtResultNumerator.DataContext = _result;
            txtResultDenominator.DataContext = _result;
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            _bus.Save(_result, "data");
            MessageBox.Show("Đã lưu thành công kết quả tính toán!");
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var list = _bus.GetAll("data");
            fractionsComboBox.ItemsSource = list;
        }
    }
}
