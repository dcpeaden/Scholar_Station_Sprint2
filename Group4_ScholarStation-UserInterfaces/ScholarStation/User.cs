using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScholarStation
{
    class User
    {
        private string name;
        private int id;
        private UserType type;

        public User()
        {
            this.name = "";
            this.id = 0;
            this.type = UserType.Null;
        }

        public User(string newName, int newId, UserType newType)
        {
            this.name = newName;
            this.id = newId;
            this.type = newType;
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                string newName = name;
            }
        }

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                int newId = id;
            }
        }

        public UserType Type
        {
            get
            {
                return type;
            }

            set
            {
                UserType newType = type;
            }
        }
    }
}
