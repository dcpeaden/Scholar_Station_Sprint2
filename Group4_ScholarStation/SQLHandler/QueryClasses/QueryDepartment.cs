using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessControler;

namespace SQLHandler
{
    public class QueryDepartment : IDepartment
    {
        private IRead read;

        public QueryDepartment()
        {
            this.read = new ConnectionControler();
        }

        public IDataReader GetDepartment()
        {
            string myCommand = "select * from department";
            return read.DataReader(myCommand);
        }
    }
}
