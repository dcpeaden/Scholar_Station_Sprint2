using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholar_Station
{
    class SessionLength : ISessionLength
    {
        private float lengthOfSession, sessionIncrementer;
        private IList<string> sessionLengthList;

        public SessionLength()
        {
            this.lengthOfSession = 0;
            this.sessionIncrementer = 15;
            this.sessionLengthList = new List<string>();
        }
        public IList<string> AddSessionLength()
        {
            for (int i = 0; i <= 3; i++)
            {
                lengthOfSession += sessionIncrementer;
                sessionLengthList.Add(lengthOfSession.ToString());
            }
            return sessionLengthList;
        }
    }
}
