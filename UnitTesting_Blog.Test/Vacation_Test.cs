using UnitTesting_Blog.Main;
using UnitTesting_Blog.Main.enums;

namespace UnitTesting_Blog.Test
{
    public class Vacation_Test
    {
            //When_Vacations_End_Date_IsEarlierThan_Start_Date_Throw_Exception
            //When_Vacation_Created_VacationState_Is_WaitingForDecision
            //Vacation_Period_Must_Ommit_Weekends -> theory
            //Vacation_Period_Counts_From_StartDate_ToEndDate -> theory


            [Theory]
            [InlineData("14/02/2022", "16/02/2022", 3, VacationState.WaitingForDecision)]
            [InlineData("14/02/2022", "14/02/2022", 1, VacationState.WaitingForDecision)]
            [InlineData("14/02/2022", "14/02/2022", 3, VacationState.WaitingForDecision)]
            [InlineData("18/02/2022", "19/02/2022", 0, VacationState.WaitingForDecision)]
            [InlineData("18/02/2022", "20/02/2022", 1, VacationState.WaitingForDecision)]
            public void Vacation_Validate(string from, string to, int period, VacationState vacationState)
            {
            //aarange
            DateTime fromDate = DateTime.Parse(from);
            DateTime toDate = DateTime.Parse(to);
            //act
             Vacation vacation = new Vacation(fromDate, toDate);
            //assert
            Assert.Equal(vacationState, vacation.State);
            Assert.Equal(period, vacation.Period);
            }
        
    }
}