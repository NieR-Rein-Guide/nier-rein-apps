using System;
using NierReincarnation.Core.Dark.View.HeadUpDisplay;

namespace NierReincarnation.Core.Dark.Calculator
{
    public static class CalculatorUserStatus
    {
        public static int GetMaxStamina()
        {
            var userId = CalculatorStateUser.GetUserId();

            var table = DatabaseDefine.User?.EntityIUserStatusTable;
            var userStatus = table?.FindByUserId(userId);

            var lvl = userStatus?.Level ?? 1;

            // CUSTOM: Calculate max stamina by user level
            // HINT: It's unclear how this part works exactly, since the code references MasterTable that is seemingly unrelated to any stamina values
            // Implementation by in-game observations
            return 50 + Math.Min(lvl - 1, 100) + Math.Max(0, lvl - 103) / 3;
        }

        public static int GetCurrentUserLevel()
        {
            var userId = CalculatorStateUser.GetUserId();

            var table = DatabaseDefine.User?.EntityIUserStatusTable;
            var userStatus = table?.FindByUserId(userId);

            return userStatus?.Level ?? 0;
        }

        public static int GetCurrentStamina()
        {
            return Stamina.CalculateCurrentStamina();
        }
    }
}
