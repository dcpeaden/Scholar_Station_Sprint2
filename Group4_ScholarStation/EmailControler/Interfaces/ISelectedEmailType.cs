using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailControler
{
    public interface ISelectedEmailType
    {
        string SelectedEmailType(string reciversEmail, string sessionID);
    }
}
