using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessControler;
using ScholarStation;

namespace SQLHandler
{
    class JoinSessions : IJoinSession
    {
        private IUpdate update;

        public JoinSessions()
        {
            update = new ConnectionControler();
        }

        public void JoinSession(string userEmail, string joinSession)
        {
            string myCommand = "UPDATE t_session  SET ses_student_email = '" 
                               + userEmail + "' Where sessionID = '" 
                               + joinSession + "'";
            update.ExecuteQueries(myCommand);
        }
    }
}
