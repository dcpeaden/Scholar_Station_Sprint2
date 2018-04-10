using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessControler
{
    public interface IRead
    {
        SqlDataReader DataReader(string Query_m);
    }
}
