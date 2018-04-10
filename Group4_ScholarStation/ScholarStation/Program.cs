using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScholarStation
{
    class Program
    {
        static void Main(string[] args)
        {
            UserFactory factory = new UserFactory();
            User firstUser = factory.CreateUser(UserType.Standard);
            User secondUser = factory.CreateUser(UserType.Professor);

            User[] userArr = new User[2];
            userArr[0] = firstUser;
            userArr[1] = secondUser;

            for (int i = 0; i < userArr.Length; i++)
            {
                Console.WriteLine("|NAME:\t" + userArr[i].Name + "\t|ID:\t" + userArr[i].Id + "\t|TYPE:\t" + userArr[i].Type + "\t|");
            }
            Console.Read();
        }
    }
}
