using System;
using NierReincarnation.Core.Dark.Calculator;
using NierReincarnation.Core.Dark.Networking;
using NierReincarnation.Core.Subsystem.Calculator.Outgame;
using NierReincarnation.Core.Subsystem.Serval;

namespace NierReincarnation.Core.Dark.View.HeadUpDisplay
{
    public static class Stamina
    {
        // CUSTOM: Made public and static for dynamic use of stamina calculation
        public static int CalculateCurrentStamina()
        {
            var userId = CalculatorStateUser.GetUserId();

            var table = DatabaseDefine.User.EntityIUserStatusTable;
            var userStatus = table.FindByUserId(userId);
            if (userStatus == null)
                return 0;

            var staminaMilli = userStatus.StaminaMilliValue;
            var maxStamina = CalculatorUserStatus.GetMaxStamina();

            if (userStatus.StaminaUpdateDatetime == 0)
                throw new ArgumentNullException(nameof(userStatus.StaminaUpdateDatetime));

            var now = CalculatorDateTime.UnixTimeNow();
            var staminaRecoverySecond = Config.GetStaminaRecoverySecond();

            return (int)UserServal.calcCurrentStaminaMilliValueAndMaxRecoveryDatetime(staminaMilli, userStatus.StaminaUpdateDatetime, maxStamina * 1000, now, staminaRecoverySecond).Item1 / 1000;
        }
    }
}
