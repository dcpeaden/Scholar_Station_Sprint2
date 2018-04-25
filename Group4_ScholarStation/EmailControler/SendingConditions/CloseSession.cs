using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailControler
{
    public class CloseSession : ISelectedEmailType
    {
        private IMailControler mailControler;
        private string body;

        public CloseSession()
        {
            this.mailControler = new MailControler();
            this.body = " ";
        }

        public string SelectedEmailType(string reciverEmail,  string sessionID)
        {
            body = "SessionID: " + sessionID + " tutoring session has been closed.";
            return mailControler.SendEmail(reciverEmail, "Cancle Session", body);
        }
    }
}
