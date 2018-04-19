using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailControler
{
    class CancleSession : ISelectedEmailType
    {
        private IMailControler mailControler;
        string body;

        public CancleSession()
        {
            this.mailControler = new MailControler();
            this.body = " ";
        }

        public string SelectedEmailType(string reciverEmail,  string sessionID)
        {
            body = "SessionID: " + sessionID + " tutoring session has been cancled.";
            return mailControler.SendEmail(reciverEmail, "Cancle Session" , body);
        }
    }
}
