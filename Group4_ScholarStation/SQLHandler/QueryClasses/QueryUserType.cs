using DataAccessControler;
using ScholarStation;
using SQLHandler.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLHandler.QueryClasses
{
    public class QueryUserType : IUserType
    {
        private IRead read;

        public QueryUserType()
        {
            this.read = new ConnectionControler();
        }

        public IDataReader GetUserType(string email, string password)
        {
            string myCommand = "select user_type from users where user_email = '" + email + "' And user_password = '" + password + "'";
            SqlDataReader userType = read.DataReader(myCommand);

            return userType;

        }
    }
}
