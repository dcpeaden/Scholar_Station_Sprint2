using System;
using System.Collections;
using System.Data.SqlClient;

namespace DataAccessControler
{
    public interface IConnection
    {
        bool closeConnection();

        bool openConnection();
    }
}
