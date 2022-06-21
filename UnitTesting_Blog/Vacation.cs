using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting_Blog
{
    public  class Vacation
    {
        //When_Vacations_End_Date_IsEarlierThan_Start_Date_Throw_Exception
        //When_Vacation_Is_Created_First_State_Is_WaitingForDecision
        //Vacation_Period_Must_Ommit_Weekends
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
        //VacationDaysMustOmmit_Weekends
        //VacatiosDays
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
