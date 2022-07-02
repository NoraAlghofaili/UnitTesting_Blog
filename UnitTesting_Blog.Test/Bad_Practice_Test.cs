using System.Globalization;
using UnitTesting_Blog.Main;
using UnitTesting_Blog.Main.enums;

namespace UnitTesting_Blog.Test
{
    public class Bad_Practice_Test
    {
        [Theory]
        [InlineData("14/02/2022", "16/02/2022", 3, VacationType.Annual, VacationState.WaitingForDecision)]
        [InlineData("14/02/2022", "16/02/2022", 3, VacationType.SickLeave, VacationState.Approved)]
        [InlineData("14/02/2022", "14/02/2022", 1, VacationType.Annual, VacationState.WaitingForDecision)]
        [InlineData("18/02/2022", "19/02/2022", 0, VacationType.Annual, VacationState.WaitingForDecision)]
        [InlineData("18/02/2022", "20/02/2022", 1, VacationType.Annual, VacationState.WaitingForDecision)]
        public void Vacation_Validate(string from, string to, int period, VacationType vacationType, VacationState vacationState)
        {
            //aarange
            DateTime fromDate = DateTime.ParseExact(from, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime toDate = DateTime.ParseExact(to, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            //act
            Vacation vacation = new Vacation(fromDate, toDate, vacationType);
            //assert
            Assert.Equal(vacationState, vacation.State);
            Assert.Equal(period, vacation.Period);
        }
    }
}