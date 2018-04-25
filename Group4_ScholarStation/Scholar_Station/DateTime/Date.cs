using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholar_Station 
{
    public class Date : IDate
    {
        private int year;
        private int month;
        private int day;
        private int[] days;
        private IList<string> date;

        public Date()
        {
            this.year = DateTime.Now.Year;
            this.month = DateTime.Now.Month;
            this.day = DateTime.Now.Day;
            this.days = Enumerable.Range(1, DateTime.DaysInMonth(year, month)).ToArray();
            this.date = new List<string>();
        }
        public IList<string> FillDate()
        {
            for (int i = 0; i <= days.Length - 1; i++)
            {
                if (i >= day)
                {
                    date.Add(month + "/" + days[i] + "/" + year);
                }
            }
            return date;
        }
    }
}
