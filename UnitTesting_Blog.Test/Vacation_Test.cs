using System.Globalization;
using UnitTesting_Blog.Main;
using UnitTesting_Blog.Main.enums;

namespace UnitTesting_Blog.Test
{
    public class Vacation_Test
    {

        #region [bad practice ooh]
        [Theory]
            [InlineData("14/02/2022", "16/02/2022", 3,VacationType.Annual, VacationState.WaitingForDecision)]
            [InlineData("14/02/2022", "16/02/2022", 3,VacationType.SickLeave, VacationState.Approved)]
            [InlineData("14/02/2022", "14/02/2022", 1, VacationType.Annual, VacationState.WaitingForDecision)]
            [InlineData("18/02/2022", "19/02/2022", 0, VacationType.Annual, VacationState.WaitingForDecision)]
            [InlineData("18/02/2022", "20/02/2022", 1, VacationType.Annual, VacationState.WaitingForDecision)]
            public void Vacation_Validate(string from, string to, int period,VacationType vacationType, VacationState vacationState)
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
        #endregion
        [Fact]
        public void Vacation_With_End_Date_EarlierThan_Start_Date_Throw_Exception()
        {
            //aarange
            DateTime fromDate = DateTime.Now;
            DateTime toDate = DateTime.Now.AddDays(-1);
            //act && assert
            Assert.Throws<Exception>(() => new Vacation(fromDate, toDate, VacationType.Annual)).Message.Equals("Vacation cannot end before it starts (:");
        }
        [Theory]
        [InlineData(VacationType.Annual, VacationState.WaitingForDecision)]
        [InlineData(VacationType.BusinessLeave, VacationState.WaitingForDecision)]
        [InlineData(VacationType.SickLeave, VacationState.Approved)]
        public void SickLeave_VacationState_always_Approved_Otherwise_WaitingForDecision(VacationType vacationType, VacationState vacationState)
        {
            //aarange
            DateTime fromDate = DateTime.Now;
            DateTime toDate = DateTime.Now.AddDays(1);
            //act
            Vacation vacation = new Vacation(fromDate, toDate, vacationType);
            //assert
            Assert.Equal(vacationState, vacation.State);
        }
        [Theory]
        [InlineData("18/02/2022", "19/02/2022", 0)]
        [InlineData("18/02/2022", "20/02/2022", 1)]
        [InlineData("14/02/2022", "14/02/2022", 1)]
        [InlineData("14/02/2022", "16/02/2022", 3)]
        public void Vacation_Period_Counts_Business_Days_From_StartDate_ToEndDate(string from, string to, int period)
        {
            //aarange
            DateTime fromDate = DateTime.ParseExact(from, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime toDate = DateTime.ParseExact(to, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            //act
            Vacation vacation = new Vacation(fromDate, toDate, VacationType.Annual);
            //assert
            Assert.Equal(period, vacation.Period);
        }
    }
}