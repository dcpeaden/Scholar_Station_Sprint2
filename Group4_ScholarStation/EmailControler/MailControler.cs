using System;
using System.Net.Mail;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Windows;
using MailBee;
using MailBee.SmtpMail;
using MailBee.Security;
using System.Text;

namespace EmailControler
{
    public class MailControler : IMailControler
    {
        private string result;

        public MailControler()
        {
            this.result = "Tutor notified";
        }
        public string SendEmail(string address, string subject, string body)
        {
            try { 
            SmtpClient SmtpServer = new SmtpClient("smtp.live.com");
            var mail = new MailMessage();
            mail.From = new MailAddress("scholarstation2018@hotmail.com");
            mail.To.Add(address.ToString());
            mail.Subject = subject.ToString();
            mail.IsBodyHtml = true;
            string htmlBody;
            htmlBody = body.ToString();
            mail.Body = htmlBody;
            SmtpServer.Port = 587;
            SmtpServer.UseDefaultCredentials = false;
            SmtpServer.Credentials = new System.Net.NetworkCredential("scholarstation2018@hotmail.com", "se2se2se2se2!");
            SmtpServer.EnableSsl = true;
            SmtpServer.Send(mail);
            result = "Message Sent Successfully";
            }catch (Exception ex)
            {
                return ex.Message;
            }
            return result;
        }
    }
}