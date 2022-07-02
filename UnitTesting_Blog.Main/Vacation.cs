using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTesting_Blog.Main.enums;

namespace UnitTesting_Blog.Main
{
    public  class Vacation
    {
        public Vacation(DateTime from, DateTime to, VacationType type)
        {
            if (to < from)
                throw new Exception("Vacation cannot end before it starts (:");

            this.From = from;
            this.To = to;
            this.Type = type;
            SetStatus(this.Type);
            this.Period = Days();
        }

        private void SetStatus(VacationType type)
        {
            if (type == VacationType.SickLeave)
                this.State = VacationState.Approved;
            else
                this.State = VacationState.WaitingForDecision;
        }

        public DateTime From { get; private set; }
        public VacationType Type { get; private set; }
        public DateTime To { get; private set; }
        public VacationState State {  get; private set; }
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
                currentDate = currentDate.AddDays(1);
            }
            return days;
        }
        public void UpdateType(VacationType vacationType)
        {
            this.Type = vacationType;
            SetStatus(this.Type);
        }
    }
}
