using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using CasinoSimulation.Model.Global;
using CasinoSimulation.Model.Global.DataBase;
using CasinoSimulation.ViewModel;

namespace CasinoSimulation.Command.Registration
{
    static class ValidationCommand
    {

        public static bool PasswordValidation(string password, System.Windows.Controls.Label label)
        {
            string input = password;
            if (string.IsNullOrWhiteSpace(input))
            {
                label.Content = "Пустое поле";
                return false;
            }

            var hasNumber = new Regex(@"[0-9]+"); // есть ли число в пароле
            var hasUpperChar = new Regex(@"[A-Z]+"); // есть ли в верхнем регистре символ
            var hasLowerChar = new Regex(@"[a-z]+"); // есть ли в нижнем регистре символ
            var hasMiniMapChar = new Regex(@".{8,20}");// Длина пароля от 8 до 20

            if (!hasLowerChar.IsMatch(input))
            {

                label.Content = "Строчная буква";
                return false;
            }
            if (!hasUpperChar.IsMatch(input))
            {
                label.Content = "Заглавная буква";
                return false;
            }
            if (!hasNumber.IsMatch(input))
            {
                label.Content = "Цифра";
                return false;
            }
            if (!hasMiniMapChar.IsMatch(input))
            {
                label.Content = "Длина";
                return false;
            }

            return true;
        }

        public static bool LoginValidation(string login, System.Windows.Controls.Label label = null)
        {
            string input = login;
            var reg = new Regex(@"^[a-zA-Z][a-zA-Z0-9-_]{4,20}");
            if (string.IsNullOrWhiteSpace(input))
            {
                label.Content = "Пустое поле";
                return false;
            }

            if (!reg.IsMatch(input))
            {
                label.Content = "неверный формат!";
                return false;
            }
            DataBaseOperations dbo = new DataBaseOperations();

            if (dbo.CheckLogin(input))
            {
                label.Content = "Данный логин уже занят!";
                return false;
            }

            return true;
        }

        public static bool PhoneValidation(string phone, System.Windows.Controls.Label label)
        {
            var input = phone;
            var reg = new Regex(@"^\+375[0-9]{9}");
            if (string.IsNullOrWhiteSpace(input))
            {
                label.Content = "Пустое поле";
                return false;
            }

            if (!reg.IsMatch(input))
            {
                label.Content = "Неверный формат  +375--___--__";
                return false;
            }

            return true;
        }

        public static bool EmailValidation(string email, System.Windows.Controls.Label label)
        {
            var input = email;
            var reg = new Regex(@"^[-\w.]+@([A-z0-9][-A-z0-9]+\.)+[A-z]{2,4}$");
            if (string.IsNullOrWhiteSpace(input))
            {
                label.Content = "Пустое поле";
                return false;
            }
            if (!reg.IsMatch(input))
            {
                label.Content = "Неверный формат!";
                return false;
            }

            return true;
        }

        public static bool DateValidation(string date, System.Windows.Controls.Label label)
        {
            var input = date;
            var reg = new Regex(@"(0[1-9]|2[0-9]|3[01])-(0[1-9]|1[012])-[0-9]{4}");

            if (string.IsNullOrWhiteSpace(input))
            {
                label.Content = "Пустое поле";
                return false;
            }
            if (!reg.IsMatch(input))
            {
                label.Content = "Неверный формат!";
                return false;
            }

            return true;
        }

        public static bool CardNumberValidation(string input, System.Windows.Controls.Label label)
        {
            var reg = new Regex(@"[0-9]{16}");
            if (string.IsNullOrWhiteSpace(input))
            {
                label.Content = "Пустое поле!";
                return false;
            }

            if (!reg.IsMatch(input)) 
            {
                label.Content = "Неверный формат!";
                return false;
            }

            return true;
        }

        public static bool CardDateValidation(string input, System.Windows.Controls.Label label)
        {
            var reg = new Regex(@"(0[1-9]|1[0-2])\\(2[5-9]{2})");
            if (string.IsNullOrWhiteSpace(input))
            {
                label.Content = "Пустое поле!";
                return false;
            }
            if (!reg.IsMatch(input))
            {
                label.Content = "Неверный формат!";
                return false;
            }

            return true;
        }

        public static bool CVVCardValidation(string input, System.Windows.Controls.Label label)
        {
            var reg = new Regex(@"[0-9]{3}");
            if (string.IsNullOrWhiteSpace(input))
            {
                label.Content = "Пустое поле!";
                return false;
            }
            if (!reg.IsMatch(input))
            {
                label.Content = "Неверный формат!";
                return false;
            }

            return true;
        }

        public static bool RefCodeValidation(string input, System.Windows.Controls.Label label)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return true;
            }

            DataBaseOperations dbo = new DataBaseOperations();
            bool isEnable = dbo.CheckLogin(input);
            if (!isEnable)
            {
                label.Content = "реф. кода нету";
                return false;
            }
            return true;
        }
    }
}
