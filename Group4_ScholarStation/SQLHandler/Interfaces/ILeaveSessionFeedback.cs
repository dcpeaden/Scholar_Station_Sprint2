using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLHandler.Interfaces
{
   public interface ILeaveSessionFeedback
    {
        void LeaveFeedback(string userEmail, string sessionId, string feedback);
    }
}
