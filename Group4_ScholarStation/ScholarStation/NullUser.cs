using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScholarStation
{
    class NullUser : User
    {
        public NullUser()
        {
        }

        public NullUser(string newName, int newId, UserType newType) : base(newName, newId, newType)
        {
        }
    }
}
