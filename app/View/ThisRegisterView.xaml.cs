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

using CasinoSimulation.Command.Registration;
using CasinoSimulation.Model.Global.DataBase;
using CasinoSimulation.Model.Global;
using CasinoSimulation.Command.Menu;


namespace CasinoSimulation.View
{
    /// <summary>
    /// Логика взаимодействия для ThisRegisterView.xaml
    /// </summary>
    public partial class ThisRegisterView : UserControl
    {
        public ICommand UserPage { get; }

        public ThisRegisterView()
        {
            InitializeComponent();
        }

        private void Register(object sender, RoutedEventArgs e)
        {
            ClearErrorLabel();
            string login    = LoginTextBox.Text;
            string password = PasswordTextBox.Password;
            string phone    = PhoneTextBox.Text;
            string email    = EmailTextBox.Text;
            string birth    = BirthTextBox.Text;
            string refcode  = RefCodeTextBox.Text;
            bool isValide = true;

            if (!ValidationCommand.LoginValidation(login, ErrorLabelLogin))
            {
                isValide = false;
            }
            if (!ValidationCommand.PasswordValidation(password, ErrorLabelPassword))
            {
                isValide = false;
            }
            if (!ValidationCommand.PhoneValidation(phone, ErrorLabelPhone))
            {
                isValide = false;
            }
            if (!ValidationCommand.EmailValidation(email, ErrorLabelEmail))
            {
                isValide = false;
            }
            if (!ValidationCommand.DateValidation(birth, ErrorLabelBirth))
            {
                isValide = false;
            }
            if (!ValidationCommand.RefCodeValidation(refcode, ErrorLabelRefCode))
            {
                isValide = false;
            }

            if (isValide)
            {
                User user;
                user = new User(
                    login, password, phone, email, birth);
                user.RefCode = !string.IsNullOrWhiteSpace(refcode) ? refcode : "";

                DataBaseOperations DBOperations = new DataBaseOperations();
                DBOperations.RegistrationUser(user);
                MessageBox.Show("Успешная регистрация!");
            }
        }

        private void ClearErrorLabel()
        {
            ErrorLabelLogin.Content    = string.Empty;
            ErrorLabelPassword.Content = string.Empty;
            ErrorLabelPhone.Content    = string.Empty;
            ErrorLabelEmail.Content    = string.Empty;
            ErrorLabelBirth.Content = string.Empty;
        }

    }
}
