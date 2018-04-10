using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailControler
{
    public interface IMailControler
    {
        string SendEmail(string toAddress, string subject, string body);
    }
}
