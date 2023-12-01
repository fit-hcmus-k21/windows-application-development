using LiveCharts;
using LiveCharts.Wpf;
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
using System.Windows.Shapes;

namespace DemoValidation
{
    /// <summary>
    /// Interaction logic for ReportWindow.xaml
    /// </summary>
    public partial class ReportWindow : Window
    {
        public ReportWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            chart.Series = new LiveCharts.SeriesCollection()
            {
                new LineSeries()
                {
                    Values= new ChartValues<double> {3, 5, 7, 4},
                    Stroke = Brushes.Red,
                    Fill = Brushes.Blue,
                    Title = "Doanh thu thang 12/2019"
                },
                new ColumnSeries()
                {
                    Values = new ChartValues<double> {5, 6, 2, 7 },
                    Stroke = Brushes.Red,
                    Fill = Brushes.Yellow,
                    StrokeThickness = 2,
                    Title = "Cac san pham ban chay theo thang"
                }
            };

            chart.AxisX.Add(new Axis()
            {
                Title = "Tháng",
                Labels = new List<string> { "Jan", "Feb", "Mar", "Apr"}
            });

            pie.Series = new SeriesCollection()
            {
                new PieSeries() { DataLabels=true, LabelPoint=calcLabelPoint, Title="SP1", Values = new ChartValues<double> {3}},
                new PieSeries() { DataLabels=true, LabelPoint=calcLabelPoint, Title="SP2", Values = new ChartValues<double> {4}},
                new PieSeries() { DataLabels=true, LabelPoint=calcLabelPoint, Title="SP3", Values = new ChartValues<double> {6}},
                new PieSeries() { DataLabels=true, LabelPoint=calcLabelPoint, Title="SP4", Values = new ChartValues<double> {2}}
            };
        }

        string calcLabelPoint(ChartPoint point)
        {
            return $"{point.Y} ({point.Participation:P1})";
        }
    }
}
