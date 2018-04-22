using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLHandler.Interfaces
{
    public interface ICreateUser
    {
        string Create_User(string firstName, string lastName, string email, string password);
    }
}
