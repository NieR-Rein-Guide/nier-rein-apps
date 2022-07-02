using NierReincarnation.Core.Dark.Calculator;
using NierReincarnation.Core.Subsystem.Calculator.Outgame;

namespace NierReincarnation.Context
{
    public class UserContext
    {
        internal UserContext() { }

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
            return StaminaContext.GetCurrentStamina();
        }

        public int GetMaxStamina()
        {
            return StaminaContext.GetMaxStamina();
        }
    }
}
