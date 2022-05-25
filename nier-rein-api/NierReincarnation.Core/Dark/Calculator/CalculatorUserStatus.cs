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
            if (lvl <= 100)
                return baseStamina + (lvl - 1);

            var remainingStamina = (lvl - 100) / 3;

            return baseStamina + 100 + remainingStamina;
        }

        public static int GetCurrentUserLevel()
        {
            var userId = CalculatorStateUser.GetUserId();

            var table = DatabaseDefine.User.EntityIUserStatusTable;
            var userStatus = table.FindByUserId(userId);

            return userStatus.Level;
        }
    }
}
