using CasinoSimulation.Model.Global.DataBase;
using CasinoSimulation.ViewModel;
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

namespace CasinoSimulation.View
{
    /// <summary>
    /// Логика взаимодействия для RegisterView.xaml
    /// </summary>
    public partial class RegisterView : UserControl
    {
        public RegisterView()
        {
            InitializeComponent();
        }

        private void AutorizationClick(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBox.Text;
            string password = PasswordTextBox.Password;

            DataBaseOperations dbo = new DataBaseOperations();
            if (dbo.Autorization(login, password))
            {
                User user = dbo.GetUser(login, password);
                Application.Current.Resources["Login"] = user.Login;
                Application.Current.Resources["Password"] = user.Password;
                MessageBox.Show("Успешная авторизация!");
            } 
            else
            {
                MessageBox.Show("Ошибка! Неправильный логин либо пароль!");
            }
        }
    }
}
