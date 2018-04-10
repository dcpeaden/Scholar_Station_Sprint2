﻿using DataAccessControler;
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
    class SessionID : ISessionID
    {
        private IRead readFromDatabase;
        private IList<string> sessionIdList;
        private IConnection closeDbConnection;
        private string sessionID;

        public SessionID()
        {
            this.readFromDatabase = new ConnectionControler();
            this.sessionIdList = new List<string>();
            this.closeDbConnection = new ConnectionControler();
            this.sessionID = "";
        }
        public IList<string> GetSessionID(string email)
        {
            String myCommand = "select * from t_session where ses_tutor_email = '" + email + "'";
            SqlDataReader currentSessionList = readFromDatabase.DataReader(myCommand);

            while (currentSessionList.Read())
            {
                sessionIdList.Add(currentSessionList.GetValue(8).ToString());
            }
            return sessionIdList;
        }

        public string GetSessionID(string studentEmail, string tutorEmail)
        {
            String myCommand = "select * from t_session where ses_tutor_email = '" + studentEmail + "'AND ses_student_email = '" + tutorEmail + "'";
            SqlDataReader SessionID = readFromDatabase.DataReader(myCommand);

            while (SessionID.Read())
            {
                sessionID = SessionID.GetValue(8).ToString();
            }
            return sessionID;
        }
    }
}
