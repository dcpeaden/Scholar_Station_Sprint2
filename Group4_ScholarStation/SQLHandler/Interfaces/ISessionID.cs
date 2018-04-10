using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLHandler.Interfaces
{
    public interface ISessionID
    {
        IList<string>  GetSessionID(string email);

        string GetSessionID(string studentEmail, string tutorEmail);
    }
}
