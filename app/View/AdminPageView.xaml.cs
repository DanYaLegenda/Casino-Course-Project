using CasinoSimulation.Model.Global.DataBase;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CasinoSimulation.Model.Global;
using System.Data;

namespace CasinoSimulation.View
{
    /// <summary>
    /// Логика взаимодействия для AdminPageView.xaml
    /// </summary>
    public partial class AdminPageView : UserControl
    {
        public AdminPageView()
        {
            InitializeComponent();
            LoadAllUsers();
        }

        private void LoadAllUsers()
        {
            UserListView.ItemsSource = null;
            DataBaseOperations dbo = new DataBaseOperations();
            DataTable dT = dbo.GetAllUsers();
            UserListView.ItemsSource = dT.DefaultView;

        }

        private void BanUser(object sender, RoutedEventArgs e)
        {
            DataBaseOperations dbo = new DataBaseOperations();
            dbo.BanOrUnBanUser(UserLogin.Text, 2);
            LoadAllUsers();
        }

        private void UnBanUser(object sender, RoutedEventArgs e)
        {
            DataBaseOperations dbo = new DataBaseOperations();
            dbo.BanOrUnBanUser(UserLogin.Text, 1);
            LoadAllUsers();
        }
    }
}
