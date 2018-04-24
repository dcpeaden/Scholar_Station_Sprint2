using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLHandler.Interfaces
{
    interface ICloseSession
    {
        void CloseOutSession(string sessionID);
    }
}
