using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScholarStation
{
    public class User
    {
        private string name;
        private int id;
        private UserType type;
        private string email;

        public User()
        {
            this.name = "";
            this.id = 0;
            this.type = UserType.Null;
            this.email = "";
        }

        public User(string newName, int newId, UserType newType, string email)
        {
            this.name = newName;
            this.id = newId;
            this.type = newType;
            this.email = email;
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

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                string newEmail = email;
            }
        }
    }
}
