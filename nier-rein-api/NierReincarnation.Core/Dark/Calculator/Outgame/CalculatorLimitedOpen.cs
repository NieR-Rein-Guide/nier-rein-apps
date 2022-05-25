using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Subsystem.Calculator.Outgame;

namespace NierReincarnation.Core.Dark.Calculator.Outgame
{
    public static class CalculatorLimitedOpen
    {
        public static bool IsOpen(long userId, LimitedOpenTargetType limitedOpenTargetType, int targetId)
        {
            var table = DatabaseDefine.User.EntityIUserLimitedOpenTable;
            var element = table.FindByUserIdAndLimitedOpenTargetTypeAndTargetId((userId, limitedOpenTargetType, targetId));
            if (element == null)
                return false;

            return CalculatorDateTime.IsWithinThePeriod(element.OpenDatetime, element.CloseDatetime);
        }
    }
}
