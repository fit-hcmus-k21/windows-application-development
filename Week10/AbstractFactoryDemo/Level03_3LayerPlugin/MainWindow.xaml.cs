using System;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Windows;
using ThreeLayerContract;

namespace Level03_3LayerPlugin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var guis = new BindingList<IGUI>();
            var buses = new BindingList<IBus>();
            var daos = new BindingList<IDAO>();

            // Get list of DLL files in main executable folder
            string exePath = Assembly.GetExecutingAssembly().Location;
            string folder = Path.GetDirectoryName(exePath);
            FileInfo[] fis = new DirectoryInfo(folder).GetFiles("*.dll");

            // Load all assemblies from current working directory
            foreach (FileInfo fileInfo in fis)
            {
                var domain = AppDomain.CurrentDomain;
                Assembly assembly = domain.Load(AssemblyName.GetAssemblyName(fileInfo.FullName));

                // Get all of the types in the dll
                Type[] types = assembly.GetTypes();

                // Only create instance of concrete class that inherits from IGUI, IBus or IDao
                foreach (var type in types)
                {
                    if (type.IsClass && !type.IsAbstract)
                    {
                        if (typeof(IGUI).IsAssignableFrom(type))
                            guis.Add(Activator.CreateInstance(type) as IGUI);
                        else if (typeof(IBus).IsAssignableFrom(type))
                            buses.Add(Activator.CreateInstance(type) as IBus);
                        else if (typeof(IDAO).IsAssignableFrom(type))
                            daos.Add(Activator.CreateInstance(type) as IDAO);
                    }
                }
            }

            cmbGUIList.ItemsSource = guis;
            cmbBusList.ItemsSource = buses;
            cmbDaoList.ItemsSource = daos;
        }

        private void btnCreateProgram_Click(object sender, RoutedEventArgs e)
        {
            IGUI gui = cmbGUIList.SelectedItem as IGUI;            
            IBus bus = cmbBusList.SelectedItem as IBus;
            IDAO dao = cmbDaoList.SelectedItem as IDAO;

            bus = bus.CreateNew(dao);
            gui = gui.CreateNew(bus);

            this.Hide();

            var program = new FractionProgramWindow(gui);
            program.Show();           
        }
    }
}
