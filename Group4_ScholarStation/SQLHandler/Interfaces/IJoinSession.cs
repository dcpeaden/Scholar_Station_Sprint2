using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScholarStation;

namespace SQLHandler
{
    public interface IJoinSession
    {
        void JoinSession(string userEmail, string joinSession);
    }
}
