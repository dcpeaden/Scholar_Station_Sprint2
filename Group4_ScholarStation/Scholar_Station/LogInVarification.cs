using SQLHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Scholar_Station
{
    class LogInVarification : ILoginInVarification
    {
        private ISQLHandler sqlHandler;
        private int minPasswordLength;

        public LogInVarification()
        {
            this.sqlHandler = new SQLHandlerControler();
            this.minPasswordLength = 8;
        }
        public bool CreateAccount(string fName, string lName, string email, string password)
        {
            if (sqlHandler.CreateAccout(fName, lName, email, password))
            {
                return true;
            } else return false;
        }

        public bool CheckToSeeIfPasswordIsCorrectLength(int passwordLength)
        {
            if (passwordLength >= minPasswordLength)
            {
                return true;
            }
            else return false;
        }

        public bool CheckToSeeIfPasswordsAreSame(string password, string passwordConformation)
        {
            if (password == passwordConformation)
            {
                return true;
            }
            else return false;
        }

        public bool CheckToSeeIfValidEmailFormat(string email)
        {
            if (Regex.IsMatch(email, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                return true;
            }
            else return false;
        }

        public bool IsFormFilledOut(string fName, string lName, string email)
        {
            if (String.IsNullOrEmpty(fName) && String.IsNullOrEmpty(lName) && String.IsNullOrEmpty(email))
            {
                return false;
            }
            else return true;
        }
    }
}
