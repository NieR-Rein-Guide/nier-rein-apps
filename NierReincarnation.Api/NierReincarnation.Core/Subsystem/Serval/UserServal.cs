namespace NierReincarnation.Core.Subsystem.Serval
{
    class UserServal
    {
        public static (long, long) calcCurrentStaminaMilliValueAndMaxRecoveryDatetime(
            long lastStaminaMilli, long lastDatetime, long maxStaminaMilli,
            long nowDatetime, int staminaRecoverySecond)
        {
            if (lastStaminaMilli < maxStaminaMilli)
            {
                var local = 0L;
                if (staminaRecoverySecond != 0)
                    local = (nowDatetime - lastDatetime) / staminaRecoverySecond;

                local += lastStaminaMilli;

                lastStaminaMilli = maxStaminaMilli;
                lastDatetime = nowDatetime;

                if (local < maxStaminaMilli)
                {
                    lastStaminaMilli = local;
                    lastDatetime = nowDatetime + (maxStaminaMilli - local) * staminaRecoverySecond;
                }
            }

            return (lastStaminaMilli, lastDatetime);
        }
    }
}
