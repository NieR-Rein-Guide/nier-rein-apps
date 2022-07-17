using NierReincarnation.Core.Dark.View.HeadUpDisplay;

namespace NierReincarnation.Core.Dark.Calculator
{
    public static class CalculatorUserStatus
    {
        public static int GetMaxStamina()
        {
            var userId = CalculatorStateUser.GetUserId();

            var table = DatabaseDefine.User.EntityIUserStatusTable;
            var userStatus = table.FindByUserId(userId);

            var lvl = userStatus.Level;

            // CUSTOM: Calculate max stamina by user level
            // HINT: It's unclear how this part works exactly, since the code references MasterTable that is seemingly unrelated to any stamina values
            // Implementation by in-game observations
            var baseStamina = 50;
            if (lvl <= 101)
                return baseStamina + (lvl - 1);

            baseStamina += 100;
            return baseStamina + (lvl - 101) / 3;
        }

        public static int GetCurrentUserLevel()
        {
            var userId = CalculatorStateUser.GetUserId();

            var table = DatabaseDefine.User.EntityIUserStatusTable;
            var userStatus = table.FindByUserId(userId);

            return userStatus.Level;
        }

        public static int GetCurrentStamina()
        {
            return Stamina.CalculateCurrentStamina();
        }
    }
}
