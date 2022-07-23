using NierReincarnation.Core.Subsystem.Calculator.Outgame;

namespace NierReincarnation.Core.Dark.Calculator.Outgame
{
    public static class CalculatorBeginner
    {
        public static bool IsTargetUser(long userId)
        {
            var table = DatabaseDefine.User.EntityIUserBeginnerCampaignTable;
            var beginnerItem = table.FindByUserId(userId);
            if (beginnerItem == null)
                return false;

            var table1 = DatabaseDefine.Master.EntityMBeginnerCampaignTable;
            var masterCampaign = table1.FindByBeginnerCampaignId(beginnerItem.BeginnerCampaignId);

            var endTime = CalculatorDateTime.FromUnixTime(beginnerItem.CampaignRegisterDatetime).AddDays(masterCampaign.GrantCampaignTermDayCount);
            return CalculatorDateTime.IsWithinThePeriod(beginnerItem.CampaignRegisterDatetime, CalculatorDateTime.ToUnixTime(endTime));
        }

        public static long GetBeginnerDateTime(long userId)
        {
            var table = DatabaseDefine.User.EntityIUserBeginnerCampaignTable;
            var beginnerItem = table.FindByUserId(userId);

            return beginnerItem?.CampaignRegisterDatetime ?? 0;
        }
    }
}
