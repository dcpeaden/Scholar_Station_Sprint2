using System;
using System.Collections;
using System.Data.SqlClient;

namespace DataAccessControler
{
    public interface IConnection
    {
        void closeConnection();
    }
}
