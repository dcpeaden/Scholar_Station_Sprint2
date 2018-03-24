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
    public class ConnectionControler : IConnection
    {
        private SqlConnection myConnection;
        private SqlDataReader dr;     

        public void openConnection()
        {
            myConnection = new SqlConnection("user id='';" +
                                             "password='';" +
                                             "server=DESKTOP-C0VCBM7\\HOMESERVER;" +
                                             "database= Scholar_Station; " +
                                             "Trusted_Connection=true;"
                                             );
            try
            {
                myConnection.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show("Connection Error!");
            }
        }

        public void closeConnection()
        {
            myConnection.Close();
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
                MessageBox.Show("Data Read Error!"); 
            }
            return dr;
        }

        public void ExecuteQueries(string Query_)
        {
            openConnection();
            SqlCommand cmd = new SqlCommand(Query_, myConnection);
            cmd.ExecuteNonQuery();
        }
    }
}
