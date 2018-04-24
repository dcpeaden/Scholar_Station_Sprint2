using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholar_Station
{
    public interface ILoginInVarification
    {
        bool CheckToSeeIfPasswordsAreSame(string password, string passwordConformation);

        bool CheckToSeeIfValidEmailFormat(string email);

        bool CheckToSeeIfPasswordIsCorrectLength(int passwordLength);

        bool CreateAccount(string fName, string lName, string email, string password);

        bool IsFormFilledOut(string fName, string lName, string email);
    }
}
