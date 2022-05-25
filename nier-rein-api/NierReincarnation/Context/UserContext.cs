using NierReincarnation.Core.Dark.Calculator;
using NierReincarnation.Core.Subsystem.Calculator.Outgame;

namespace NierReincarnation.Context
{
    public class UserContext
    {
        private StaminaContext _stamina;

        internal UserContext()
        {
            _stamina = new StaminaContext();
        }

        public string GetUserName()
        {
            return CalculatorProfile.GetName(GetUserId());
        }

        public int GetUserLevel()
        {
            return CalculatorUserStatus.GetCurrentUserLevel();
        }

        public long GetUserId()
        {
            return CalculatorStateUser.GetUserId();
        }

        public int GetCurrentStamina()
        {
            return _stamina.GetCurrentStamina();
        }

        public int GetMaxStamina()
        {
            return _stamina.GetMaxStamina();
        }
    }
}
