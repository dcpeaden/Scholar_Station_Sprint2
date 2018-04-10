using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholar_Station
{
    class Time : ITime
    {
        private DateTime time;
        private IList<string> listOfTimes;

        public Time()
        {
            this.time = DateTime.Today;
            this.listOfTimes = new List<string>();
        }
        public IList<string> getTime()
        {
            //from 8h to 22h hours
            for (DateTime _time = time.AddHours(08); _time < time.AddHours(22); _time = _time.AddMinutes(15)) 
            {
                listOfTimes.Add(_time.ToShortTimeString());
            }
            return listOfTimes;
        }
    }
}
