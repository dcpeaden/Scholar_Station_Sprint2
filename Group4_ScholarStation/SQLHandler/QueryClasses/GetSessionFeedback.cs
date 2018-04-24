using SQLHandler.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessControler;

namespace SQLHandler.QueryClasses
{
    class GetSessionFeedback : IGetSessionFeedback
    {
        private IRead read;

        public GetSessionFeedback()
        {
            this.read = new ConnectionControler();
        }

        public IDataReader GetTutorFeedback(string sessionID)
        {
            string myCommand = "select feedback from tutorFeedback where sessionID = '" + sessionID + "'";
            SqlDataReader feedback_dr = read.DataReader(myCommand);
            return feedback_dr;
        }

        public IDataReader GetStudentFeedback(string sessionID)
        {
            string myCommand = "select feedback from studentFeedback where sessionID = '" + sessionID + "'";
            SqlDataReader feedback_dr = read.DataReader(myCommand);
            return feedback_dr;
        }
    }
}
