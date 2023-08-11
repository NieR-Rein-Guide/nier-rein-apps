using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_event_quest_daily_group_complete_reward")]
    public class EntityIUserEventQuestDailyGroupCompleteReward
    {
        [Key(0)]
        public long UserId { get; set; }

        [Key(1)]
        public int LastRewardReceiveEventQuestDailyGroupId { get; set; }

        [Key(2)]
        public long LastRewardReceiveDatetime { get; set; }

        [Key(3)]
        public long LatestVersion { get; set; }
    }
}
