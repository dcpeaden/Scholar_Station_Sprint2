using System;
using System.Collections;
using System.Data.SqlClient;

namespace DataAccessControler
{
    public interface IConnection
    {
        void openConnection();

        void closeConnection();

        void ExecuteQueries(string Query);

        SqlDataReader DataReader(string Query_m);
    }
}
