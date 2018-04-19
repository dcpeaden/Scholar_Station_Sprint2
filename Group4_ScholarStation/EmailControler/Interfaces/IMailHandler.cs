using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailControler
{
    public interface IMailHandler
    {
        string CancleSession(string reciversEmail, string studentName);

        string CloseSession(string reciversEmail, string studentName);

        string JoinSession(string reciversEmail, string studentName);

    }
}
