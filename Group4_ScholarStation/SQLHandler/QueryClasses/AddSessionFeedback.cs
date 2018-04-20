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
            string isUserTutor = "Select * From t_session Where ses_tutor_email = '" + userEmail + "' AND sessionID = '" + sessionId + "'";
            string courseID = " ";
            IDataReader getCourseIDForSession;

            if (reader.DataReader(isUserTutor) == null)
            {
                string courseIDQuery = "SELECT ses_course " +
                                       "FROM t_session " +
                                       "WHERE sessionId = '" + sessionId +
                                       "' AND ses_tutor_email = '" + userEmail + "'";

                getCourseIDForSession = reader.DataReader(courseIDQuery);

                while (getCourseIDForSession.Read())
                {
                    courseID = getCourseIDForSession.GetValue(0).ToString();
                }
                string addToFeedbackTable = "INSERT INTO tutorFeedback  (courseID , sessionID , feedback) VALUES('" + courseID + "','" + sessionId + "','" + feedback + "')";
                update.ExecuteQueries(addToFeedbackTable);
            }
            else
            {

                string courseIDQuery = "SELECT ses_course " +
                                       "FROM t_session " +
                                       "WHERE sessionId = '" + sessionId +
                                       "' AND ses_student_email = '" + userEmail + "'";

                getCourseIDForSession = reader.DataReader(courseIDQuery);

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
