using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScholarStation
{
     public class UserFactory : IUserFactory
    {

        public User CreateUser(String name, int id, UserType type, String email)
        {
            User user = null;

            if (type == UserType.Standard)
            {
                user = new User(name, id, UserType.Standard, email);
            }
            else if(type == UserType.Professor)
            {
                user = new User(name, id, UserType.Professor, email);
            }
            else if(type == UserType.Department)
            {
                user = new User(name, id, UserType.Department, email);
            }
            else if(type == UserType.Administrator)
            {
                user = new User(name, id, UserType.Administrator, email);
            }
            else
            {
                user = new User(name, 0, UserType.Null, null);
            }
            return user;
        }
    }
}
