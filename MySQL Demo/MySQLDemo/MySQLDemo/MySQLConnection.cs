using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace MySQLDemo
{
    public class MySQLConnection
    {
        string connectionstring = "server=localhost;uid=CAPSTONE;pwd=CAPSTONE;database=CAPSTONE;";
        MySqlConnection DatabaseConnection;

        public MySQLConnection()
        {
            DatabaseConnection = new MySqlConnection(connectionstring);
        }

        public MySqlConnection Connection
        {
            get
            {
                return DatabaseConnection;
            }
        }

        public string ConnectionString
        {
            get
            {
                return connectionstring;
            }
        }


        public void EstablishConnection()
        {
            try
            {
                DatabaseConnection.Close();
                DatabaseConnection.ConnectionString = connectionstring;
                DatabaseConnection.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void CloseConnection()
        {
            DatabaseConnection.Close();
        }
    }
}
