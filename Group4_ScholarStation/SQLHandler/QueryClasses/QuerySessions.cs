using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessControler;

namespace SQLHandler
{
    public class QuerySessions : ISessions
    {
        private IRead read;

        public QuerySessions()
        {
            this.read = new ConnectionControler();
        }

        public IDataReader GetAvailableSessions(string tutorEmail)
        {
            String myCommand = "select * from t_session where ses_tutor_email = '" + tutorEmail + "'";
            IDataReader listOfSessions_dr = read.DataReader(myCommand);
            return listOfSessions_dr;
        }

        public IDataReader GetCompletedSessionsByCourse(string courseNum)
        {
            String myCommand = "select * from t_session where ses_course = '" + courseNum + "' and  ses_complete = 1";
            IDataReader listOfSessions_dr = read.DataReader(myCommand);
            return listOfSessions_dr;
        }

    }
}
