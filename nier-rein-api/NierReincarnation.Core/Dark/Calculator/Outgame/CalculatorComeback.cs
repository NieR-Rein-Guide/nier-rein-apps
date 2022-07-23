using NierReincarnation.Core.Subsystem.Calculator.Outgame;

namespace NierReincarnation.Core.Dark.Calculator.Outgame
{
    public static class CalculatorComeback
    {
        public static bool IsTargetUser(long userId)
        {
            var table = DatabaseDefine.User.EntityIUserComebackCampaignTable;
            var comebackItem = table.FindByUserId(userId);
            if (comebackItem == null)
                return false;

            var table1 = DatabaseDefine.Master.EntityMComebackCampaignTable;
            var masterCampaign = table1.FindByComebackCampaignId(comebackItem.ComebackCampaignId);

            var endTime = CalculatorDateTime.FromUnixTime(comebackItem.ComebackDatetime).AddDays(masterCampaign.GrantCampaignTermDayCount);
            return CalculatorDateTime.IsWithinThePeriod(comebackItem.ComebackDatetime, CalculatorDateTime.ToUnixTime(endTime));
        }

        public static long GetComeBackDateTime(long userId)
        {
            var table = DatabaseDefine.User.EntityIUserComebackCampaignTable;
            var comebackItem = table.FindByUserId(userId);

            return comebackItem?.ComebackDatetime ?? 0;
        }
    }
}
