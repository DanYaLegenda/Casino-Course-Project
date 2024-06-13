using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace CasinoSimulation.Model.Global.DataBase
{
    public partial class DataBase
    {
        SqlConnection _connection = new SqlConnection(@"Data Source=DanYa;Initial Catalog=CASINO;Integrated Security=True");

        public void OpenConnection()
        {
            if (_connection.State == System.Data.ConnectionState.Closed)
            {
                _connection.Open();
            }
        }
        public void CloseConnection()
        {
            if (_connection.State == System.Data.ConnectionState.Open)
            {
                _connection.Close();
            }
        }

        public SqlConnection GetConnection()
        {
            return _connection;
        }

    }
}
