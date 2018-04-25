using DataAccessControler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLHandler.Interfaces
{
    public class ViewCurrentSessions : IViewCurrentSessions
    {
        private IRead readFromDatabase;

        public ViewCurrentSessions()
        {
            this.readFromDatabase = new ConnectionControler();
        }

        public IDataReader ViewCurrentSession(string email)
        {
            String myCommand = "select * from t_session where ses_tutor_email = '" + email + "'";
            SqlDataReader currentSessionList = readFromDatabase.DataReader(myCommand);
            return currentSessionList;
        }

        public IDataReader ViewCurrentSessionStudent(string email)
        {
            String myCommand = "select * from t_session where ses_student_email = '" + email + "'";
            SqlDataReader currentSessionList = readFromDatabase.DataReader(myCommand);
            return currentSessionList;
        }

        public IDataReader ViewCurrentSessionByID(string id)
        {
            String myCommand = "select * from t_session where sessionId = '" + id + "'";
            SqlDataReader currentSessionList = readFromDatabase.DataReader(myCommand);
            return currentSessionList;
        }
    }
}
