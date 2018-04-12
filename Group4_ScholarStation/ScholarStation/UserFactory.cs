using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScholarStation
{
    class UserFactory : IUserFactory
    {
        public User CreateUser(UserType type)
        {
            User user = null;
            Console.Write("Enter User Name: ");

            string name = Convert.ToString(Console.ReadLine());
            if (type == UserType.Standard)
            {
                user = new User(name,1,UserType.Standard);
            }
            else if(type == UserType.Professor)
            {
                user = new User(name, 2, UserType.Professor);
            }
            else if(type == UserType.Department)
            {
                user = new User(name, 3, UserType.Department);
            }
            else if(type == UserType.Administrator)
            {
                user = new User(name, 4, UserType.Administrator);
            }
            else
            {
                user = new User(name, 0, UserType.Null);
            }
            return user;
        }
    }
}
