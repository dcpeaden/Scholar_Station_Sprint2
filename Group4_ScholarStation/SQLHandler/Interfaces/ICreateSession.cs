using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLHandler.Interfaces
{
    public interface ICreateSession
    {
        void AddNewSession(string email, string date, string time, string length, string classes);

        int IsSessionIDUnique(int randomNumber);
    }
}
