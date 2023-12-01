using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Fluent;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
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

namespace DemoRibbon2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : RibbonWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BackstageTabItem_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to quit?", "Confirmation",
                MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }


        class Category
        {
            // TODO: Chèn khởi tạo với tham số
            public int Id { get; set; }
            public string Name { get; set; }
            public List<Product> Products { get; set; }
        }

        class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Price { get; set; }

        }

        List<Category> _categories;

        private void RibbonWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // TODO: Bắt thêm lỗi chưa nhập liệu
            var version = Assembly.GetExecutingAssembly().GetName().Version;
            this.Title = $"v{version}";

            _categories = new List<Category>()
            {
                new Category()
                {
                    Id = 1,
                    Name = "Laptop",
                    Products = new List<Product>()
                    {
                        new Product() {Id = 7, Name = "HP Spectre 16", Price=200000},
                        new Product() {Id = 8, Name = "Acer Chrome Book", Price=130000}
                    }
                },
                new Category()
                {
                    Id = 2,
                    Name = "Mini PC",
                    Products = new List<Product>()
                    {
                        new Product() {Id = 9, Name = "XMiNi 12", Price=167000},
                        new Product() {Id = 10, Name = "HP Mini Desk", Price=199000}
                    }
                },
                new Category()
                {
                    Id = 3,
                    Name = "Keyboard",
                    Products = new List<Product>()
                    {
                        new Product() {Id = 9, Name = "Logitech", Price=300000},
                        new Product() {Id = 10, Name = "Microsoft", Price=459000}
                    }
                }
            };
            categoriesComboBox.ItemsSource = _categories;

            string filename = "Book1.xlsx";
            var document = SpreadsheetDocument.Open(filename, false);
            var wbPart = document.WorkbookPart!;
            var sheets = wbPart.Workbook.Descendants<Sheet>()!;

            foreach(var tab in sheets)
            {
                Debug.WriteLine(tab.Name);
            }

            var sheet = sheets.FirstOrDefault(s => s.Name == "Category");
            var wsPart = (WorksheetPart)(wbPart!.GetPartById(sheet.Id!));
            var stringTable = wbPart
                    .GetPartsOfType<SharedStringTablePart>()
                    .FirstOrDefault()!;
            var cells = wsPart.Worksheet.Descendants<Cell>();

            int row = 3;
            Cell idCell;

            do
            {
                idCell = cells.FirstOrDefault(
                c => c?.CellReference == $"B{row}"
                )!;

                if (idCell?.InnerText.Length > 0)
                {
                    string id = idCell.InnerText;
                    Cell nameCell = cells.FirstOrDefault(
                        c => c?.CellReference == $"C{row}"
                    )!;
                    string stringId = nameCell!.InnerText;
                    string name = stringTable.SharedStringTable
                            .ElementAt(int.Parse(stringId))
                            .InnerText;

                    Debug.WriteLine($"{id}-{name}");
                }
                row++;
            } while (idCell?.InnerText.Length > 0);
        }
    }
}
