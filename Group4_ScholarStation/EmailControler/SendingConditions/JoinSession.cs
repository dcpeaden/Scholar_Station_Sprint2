using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailControler
{
    class JoinSession : ISelectedEmailType
    {
        private IMailControler mailControler;
        private string body;

        public JoinSession()
        {
            this.mailControler = new MailControler();
            this.body = " ";
        }

        public string SelectedEmailType(string reciverEmail, string sessionID)
        {
            body = "Student " + reciverEmail + " has joined tutoring session " + sessionID + ".";
            return mailControler.SendEmail(reciverEmail, "Cancled Session", body);
        }
    }
}
