﻿using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private async void loginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = userNameTextBox.Text;
            string password = passwordBox.Password;

            loading.IsIndeterminate = true;

            // Cộng chuỗi - sql injection
            var builder = new SqlConnectionStringBuilder();
            builder.DataSource = "localhost"; 


            builder.InitialCatalog = "BookShop";
            builder.UserID = username; 
            builder.Password = password;
            builder.TrustServerCertificate = true;

            string connectionString = builder.ConnectionString;
            var connection = new SqlConnection(connectionString);



            connection = await Task.Run(() => {
                var _connection = new SqlConnection(connectionString);

                try
                {
                    _connection.Open();
                    //MessageBox.Show("Connect success");
                }
                catch (Exception ex)
                {

                    _connection = null;
                    MessageBox.Show("Connect failed: " + ex.Message);
                }

                // Test khi chạy quá nhanh
                //System.Threading.Thread.Sleep(3000);
                return _connection;
            });

            loading.IsIndeterminate = false;

                if (connection != null)
                {
                    if (rememberMe.IsChecked == true)
                    {
                        var passwordInBytes = Encoding.UTF8.GetBytes(password);
                        var entropy = new byte[20];
                        using (var rng = new RNGCryptoServiceProvider())
                        {
                            rng.GetBytes(entropy);
                        }
                        var cypherText = ProtectedData.Protect(passwordInBytes, entropy,
                            DataProtectionScope.CurrentUser);
                        var passwordIn64 = Convert.ToBase64String(cypherText);
                        var entropyIn64 = Convert.ToBase64String(entropy);

                        var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                        config.AppSettings.Settings["Username"].Value = username;
                        config.AppSettings.Settings["Password"].Value = passwordIn64;
                        config.AppSettings.Settings["Entropy"].Value = entropyIn64;
                        config.Save(ConfigurationSaveMode.Minimal);

                        ConfigurationManager.RefreshSection("appSettings");
                    }

                    DB.Instance.ConnectionString = connectionString;

                    var screen = new MainWindow();
                    screen.Show();

                    this.Close();
                } else
                {
                MessageBox.Show("Connection is null");
                }
         
                
            
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var passwordIn64 = ConfigurationManager.AppSettings["Password"];
            
            if (passwordIn64.Length != 0)
            {
                var entropyIn64 = ConfigurationManager.AppSettings["Entropy"];

                var cyperTextInBytes = Convert.FromBase64String(passwordIn64);
                var entropyInBytes = Convert.FromBase64String(entropyIn64);

                var passwordInBytes = ProtectedData.Unprotect(cyperTextInBytes, entropyInBytes,
                    DataProtectionScope.CurrentUser);
                var password = Encoding.UTF8.GetString(passwordInBytes);
                passwordBox.Password = password;

                userNameTextBox.Text = ConfigurationManager.AppSettings["Username"];
            }
        }
    }
}
