using System.Globalization;
using UnitTesting_Blog.Main;
using UnitTesting_Blog.Main.enums;

namespace UnitTesting_Blog.Test
{
    public class Overlapping_Test
    {
        private static readonly Vacation _vacation = new Vacation(DateTime.Now, DateTime.Now.AddDays(1), VacationType.BusinessLeave);
        [Fact]
        public void BusinessLeave_Has_WaitingForDecision_State()
        {
            //arrange
            var vacation = _vacation;
            //assert
            Assert.Equal(VacationState.WaitingForDecision, _vacation.State);
        }
        [Fact]
        public void Update_Vacation_To_SickLeave_Must_Update_Status_To_Approved()
        {
            //act
            _vacation.UpdateType(VacationType.SickLeave);
            //assert
            Assert.Equal(VacationState.Approved, _vacation.State);
        }
    }
}