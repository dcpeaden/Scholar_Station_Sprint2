using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailControler
{
    public class MailHandler : IMailHandler
    {
        private ISelectedEmailType joinSession;
        private ISelectedEmailType cancelSession;
        private ISelectedEmailType closeSession;

        public MailHandler()
        {
            this.joinSession = new JoinSession();
            this.cancelSession = new CancleSession();
            this.closeSession = new CloseSession();
        }

        public string CancleSession(string sendersrName, string sessionID)
        {
            return joinSession.SelectedEmailType(sendersrName,  sessionID);
        }

        public string CloseSession(string sendersrName, string sessionID)
        {
            return closeSession.SelectedEmailType(sendersrName, sessionID);
        }

        public string JoinSession(string sendersrName, string sessionID)
        {
            return joinSession.SelectedEmailType(sendersrName, sessionID);
        }
    }
}
