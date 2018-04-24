using DataAccessControler;
using SQLHandler.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLHandler.QueryClasses
{
    class CloseSession : ICloseSession
    {
        private IUpdate update;

        public CloseSession()
        {
            this.update = new ConnectionControler();
        }

        public void CloseOutSession(string sessionID)
        {
            String command = "UPDATE t_session SET ses_complete = 1 WHERE sessionId = '" + sessionID + "'";
            update.ExecuteQueries(command);
        }
    }
}
