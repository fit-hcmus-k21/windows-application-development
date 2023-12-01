using Contract;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DemoFraction
{
    /// <summary>
    /// Interaction logic for BasicUserControl.xaml
    /// </summary>
    public partial class BasicUserControl : UserControl
    {
        IBus _bus;
        public BasicUserControl(IBus bus)
        {
            _bus = bus;
            InitializeComponent();
        }

        BindingList<Fraction> _fractions = new BindingList<Fraction>();
        Fraction _result = new Fraction();

        private void UserControl_Initialized(object sender, EventArgs e)
        {
            _fractions = _bus.GetAllFractions();
            fractionsListView.ItemsSource = _fractions;
        }

        private void calcSumButton_Click(object sender, RoutedEventArgs e)
        {
            int num1 = int.Parse(firstNumTextBox.Text);
            int den1 = int.Parse(firstDenTextBox.Text);
            Fraction f1 = new Fraction(num1, den1);

            int num2 = int.Parse(secondNumTextBox.Text);
            int den2 = int.Parse(secondDenTextBox.Text);
            Fraction f2 = new Fraction(num2, den2);
            
            _result = _bus.Add(f1, f2);
            resultNumTextBox.Text = _result.Numerator.ToString();
            resultDenTextBox.Text = _result.Denominator.ToString();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            _bus.AddFraction(_result);
            _fractions.Add(_result);
        }
    }
}
