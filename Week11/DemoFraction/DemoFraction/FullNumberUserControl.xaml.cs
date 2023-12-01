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
    /// Interaction logic for FullNumberUserControl.xaml
    /// </summary>
    public partial class FullNumberUserControl : UserControl
    {
        IBus _bus;
        public FullNumberUserControl(IBus bus)
        {
            _bus = bus;
            InitializeComponent();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            _bus.AddFraction(_result);
            _fractions.Add(_result);
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
            Fraction f1 = Fraction.Parse(firstTextBox.Text);
            Fraction f2 = Fraction.Parse(secondTextBox.Text);

            _result = _bus.Add(f1, f2);
            resultTextBox.Text = _result.ToString();
        }
    }
}
