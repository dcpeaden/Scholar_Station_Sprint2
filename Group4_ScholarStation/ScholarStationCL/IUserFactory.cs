using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScholarStation
{
    public interface IUserFactory
    {
        User CreateUser(String name, int id, UserType type, String email);
    }
}
