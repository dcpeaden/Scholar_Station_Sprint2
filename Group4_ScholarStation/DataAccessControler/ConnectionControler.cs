using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Collections;
using System.Data;
using System.Windows;

namespace DataAccessControler
{
    public class ConnectionControler : IConnection, IUpdate, IRead
    {
        private string connectionString = "user id='';" + "password='';" + "server=localhost;" + "database= Scholar_Station; " + "Trusted_Connection=true;";
        private SqlConnection myConnection;
        private SqlDataReader dr;

        public ConnectionControler()
        {
                this.myConnection = new SqlConnection(connectionString);
        }

        public bool openConnection()
        {
            try
            {
                myConnection = new SqlConnection(connectionString);
                myConnection.Open();
                return true;
            }
            catch
            {
                MessageBox.Show("Error Opening Connection!");
                return false;
            }
            
        }

        public bool closeConnection()
        {
            myConnection.Close();
            ConnectionState state = myConnection.State;
            if (state == ConnectionState.Closed)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Error Closing Connection!");
                return false;
            }
        }

        public SqlDataReader DataReader(String Query_)
        {
            try
            {
                openConnection();
                SqlCommand cmd = new SqlCommand(Query_, myConnection);
                SqlDataReader dr = cmd.ExecuteReader();
                return dr;
            }
            catch
            {
                //MessageBox.Show("Data Read Error!");
                return dr = null;
            }
        }

        public bool ExecuteQueries(string Query_)
        {
            try
            {
                openConnection();
                SqlCommand cmd = new SqlCommand(Query_, myConnection);
                cmd.ExecuteNonQuery();
                closeConnection();
                return true;
            }
            catch
            {
                //MessageBox.Show("Data Write Error!");
                return false;
            }
        }
    }
}
