using DataAccessControler;
using SQLHandler.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLHandler.QueryClasses
{
    class AddSessionFeedback : ILeaveSessionFeedback
    {
        private IRead reader;
        private IUpdate update;

        public AddSessionFeedback()
        {
            this.reader = new ConnectionControler();
            this.update = new ConnectionControler();
        }

        public void LeaveFeedback(string userEmail, string sessionId, string feedback)
        {
            string isUserTutor = "Select * From t_sessions Where ses_tutor_email = '" + userEmail + "' AND sessionID = '" + sessionId + "'";
            string courseID = " ";
            string courseIDQuery = "SELECT t_session.ses_course " + 
                                   "FROM t_session " +
                                   "WHERE t_session.sessionId = '" + sessionId + 
                                   "' AND ses_tutor_email = '" + userEmail + "'";
            IDataReader getCourseIDForSession = reader.DataReader(courseIDQuery);


            if (reader.DataReader(isUserTutor) == null)
            {
                while (getCourseIDForSession.Read()){
                    courseID = getCourseIDForSession.GetValue(0).ToString();
                }
                string addToFeedbackTable = "INSERT INTO tutorFeedback  (courseID , sessionID , feedback) VALUES('" + courseID + "','" + sessionId + "','" + feedback + "')";
                update.ExecuteQueries(addToFeedbackTable);
            }
            else
            {
                while (getCourseIDForSession.Read())
                {
                    courseID = getCourseIDForSession.GetValue(0).ToString();
                }
                string addToFeedbackTable = "INSERT INTO studentFeedback  (courseID , sessionID , feedback) VALUES('" + courseID + "','" + sessionId + "','" + feedback + "')";
                update.ExecuteQueries(addToFeedbackTable);
            }

        }
    }
}
