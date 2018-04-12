using DataAccessControler;
using SQLHandler.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLHandler.QueryClasses
{
    class CreateSession : ICreateSession
    {
        private IRead readFromDatabase;
        private IConnection closeDbConnection;
        private IUpdate updateDatabase;
        private int sessID, numberOfAllowedSessions;

        public CreateSession()
        {
            this.readFromDatabase = new ConnectionControler();
            this.closeDbConnection = new ConnectionControler();
            this.updateDatabase = new ConnectionControler();
            this.sessID = 0;
            this.numberOfAllowedSessions = 1000;
        }
        public void AddNewSession(string email, string date, string time, string length, string classes)
        {
            Random ran = new Random();
            int numberOfAllowedSessions = 10000;
            sessID = IsSessionIDUnique(ran.Next(numberOfAllowedSessions));

            string insertIntoSessions = "INSERT into t_session (ses_tutor_email , ses_student_email, ses_date, ses_start_time, ses_duration, ses_creator, ses_complete, ses_course, sessionId ) " +
                               "VALUES ('" + email
                                + "', '" + null
                                + "', '" + date
                                + "', '" + time
                                + "', '" + length
                                + "', '" + email
                                + "', '" + 0
                                + "', '" + classes
                                + "', '" + sessID + "')";

            updateDatabase.ExecuteQueries(insertIntoSessions);

            string insertIntotutors = "INSERT into tutors (tutor_email , tutor_cr_num, tutor_is_endorsed, fk_sessionID ) " +
                               "VALUES ('" + email
                                + "', '" + classes
                                + "', '" + 0
                                + "', '" + sessID + "')";

            updateDatabase.ExecuteQueries(insertIntotutors);
        }

        public int IsSessionIDUnique(int newIdNumber)
        {
            IRead readFromDatabase = new ConnectionControler();

            String myCommand = "select sessionId from t_session";
            SqlDataReader sessionIdList = readFromDatabase.DataReader(myCommand);
            while (sessionIdList.Read())
            {
                if ((int)sessionIdList.GetValue(0) == newIdNumber)
                {
                    newIdNumber = IsSessionIDUnique(new Random().Next(newIdNumber));

                }
            }
            return newIdNumber;
        }
    }
}
