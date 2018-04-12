using DataAccessControler;
using SQLHandler.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLHandler.QueryClasses
{
    class CancelSessions : ICancelSession
    {
        private IUpdate updateDatabase;

        public CancelSessions()
        {
            this.updateDatabase = new ConnectionControler();
        }

        public void CancelSession(string sessionToCancel)
        {
            String deleteSessionFromSessionTable = "Delete From t_session where sessionId = '" + sessionToCancel + "'";
            updateDatabase.ExecuteQueries(deleteSessionFromSessionTable);

            String deleteSessionFromTutorTable = "Delete From tutors where fk_sessionId = '" + sessionToCancel + "'";
            updateDatabase.ExecuteQueries(deleteSessionFromTutorTable);
        }
    }
}
