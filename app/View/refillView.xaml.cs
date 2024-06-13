using CasinoSimulation.Command.Registration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CasinoSimulation.View
{
    /// <summary>
    /// Логика взаимодействия для refillView.xaml
    /// </summary>
    public partial class refillView : UserControl
    {
        public refillView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool isValid = true;
            ClearErrorLabel();
            if (!ValidationCommand.CardNumberValidation(CardNameTextBox.Text, ErrorLabelCardName))
            {
                isValid = false;
            }
            if (!ValidationCommand.CVVCardValidation(CVVTextBox.Password, ErrorLabelCVV))
            {
                isValid = false;
            }
            if (!ValidationCommand.CardDateValidation(DateTextBox.Text, ErrorLabelDateCard))
            {
                isValid = false;
            }
            if (!Regex.IsMatch(SumTextBox.Text, @"[0-9]") && string.IsNullOrWhiteSpace(SumTextBox.Text))
            {
                isValid = false;
            }
            if (isValid)
            {
                Application.Current.Resources["Value"] = SumTextBox.Text;
                MessageBox.Show("Успешное пополнение!");
            }
        }

        private void ClearErrorLabel()
        {
            ErrorLabelCardName.Content = string.Empty;
            ErrorLabelCVV.Content = string.Empty;
            ErrorLabelDateCard.Content = string.Empty;
        }
    }
}
