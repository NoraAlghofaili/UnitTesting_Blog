using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting_Blog
{
    public  class Vacation
    {
        public Vacation(DateTime from, DateTime to)
        {
            if (to > from)
                throw new Exception("Vacation cannot end before it starts (:");
            this.From = from;
            this.To = to;
            this.State = VacationState.WaitingForDecision;
            this.Period = Days();
        }
        public DateTime From { get; private set; }
        public DateTime To { get; private set; }
        public VacationState State { private get; set; }
        public int Period { get; private set; }
        private int Days()
        {
            var currentDate = From;
            var days = 0;
            while(currentDate <= To) {
                if(currentDate.DayOfWeek != DayOfWeek.Friday && currentDate.DayOfWeek != DayOfWeek.Saturday)
                {
                    days++;
                }
                currentDate.AddDays(1);
            }
            return days;
        }
    }
}
