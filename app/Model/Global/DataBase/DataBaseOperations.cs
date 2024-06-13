using CasinoSimulation.Command.Roulette;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows;
using System.Data.SqlClient;

namespace CasinoSimulation.Model.Global.DataBase
{
    public class DataBaseOperations
    {
        DataBase dataBase = new DataBase();

        public void RegistrationUser(User user)
        {
            string queryString = $"INSERT INTO USERS(login, password, phone, email, bird_date, ref_code) VALUES ('{user.Login}', '{HashPassword.Hash(user.Password)}', '{user.Phone}', '{user.Email}', '{user.BirthDate}', '{user.RefCode}')";
            SqlCommand command = new SqlCommand(queryString, dataBase.GetConnection());
            dataBase.OpenConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Аккаунт успешно создан", "Error");
            }
        }

        public DataTable GetAllUsers()
        {
            DataTable table = new DataTable();
            string query = $"select USERS.id, login, balance, phone, email, ROLES.name_role, BANNES.status from USERS inner join ROLES on USERS.roles = ROLES.id_role inner join BANNES on USERS.is_baned = BANNES.id ";
            try
            {

                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand sqlCommand = new SqlCommand(query, dataBase.GetConnection());
                adapter.SelectCommand = sqlCommand;
                adapter.Fill(table);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Упс");
            }

            return table;
        }

        public bool Autorization(string login, string password)
        {
            string pass = HashPassword.Hash(password);
            string qureyString = $"select id, login, password, balance, roles, is_baned from USERS where login = '{login}' and password = '{pass}'";

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            SqlCommand sqlCommand = new SqlCommand(qureyString, dataBase.GetConnection());

            adapter.SelectCommand = sqlCommand;
            adapter.Fill(table);

            if (table.Rows.Count == 0)
            {
                return false;
            }

            if ((int)table.Rows[0][5] == 2)
            {
                MessageBox.Show("Упс, а вы забанены!");
                return false;
            }

            return true;
        }

        public void BanOrUnBanUser(string login, int ban) 
        {
            string qureyString = $"Update USERS SET is_baned = {ban} where login = '{login}'";
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(qureyString, dataBase.GetConnection());
                dataBase.OpenConnection();
                adapter.SelectCommand.ExecuteNonQuery();
                
                string res = (ban == 2) ? "Пользователь забанен!" : "Пользователь разбанен";
                
                MessageBox.Show(res);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось найти пользователя!");
            }
        }

        public void SaveUser(string login, int balance)
        {
            string query = $"UPDATE USERS SET balance = {balance} where login = '{login}'";

            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, dataBase.GetConnection());
                dataBase.OpenConnection();
                adapter.SelectCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {

            }
        }

        public User GetUser(string login, string password, bool isHash = false)
        {
            User user = new User();

            string pass = isHash ? password : HashPassword.Hash(password);
            string qureyString = $"select id, login, password, balance, roles from USERS where login = '{login}' and password = '{pass}'";
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataTable table = new DataTable();
                SqlCommand sqlCommand = new SqlCommand(qureyString, dataBase.GetConnection());
                dataBase.OpenConnection();

                adapter.SelectCommand = sqlCommand;
                adapter.Fill(table);

                SqlDataReader reader = sqlCommand.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    user.Id = Convert.ToInt32(reader[0]);
                    user.Login = reader[1].ToString();
                    user.Password = reader[2].ToString();
                    user.Bankroll = Convert.ToInt32(reader[3]);
                    user.Role = Convert.ToInt32(reader[4]);
                }
                reader.Close();
                user.isAutorize = true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка Получения пользователя!");
            }

            return user;
        }

        public bool CheckLogin(string login)
        {
            string qureyString = $"select login from USERS where login = '{login}'";

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            SqlCommand sqlCommand = new SqlCommand(qureyString, dataBase.GetConnection());

            adapter.SelectCommand = sqlCommand;
            adapter.Fill(table);
            

            if (table.Rows.Count == 1)
            {
                return true;
            }
            return false;
        }
    }
}
