using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_event_quest_daily_group_complete_reward")]
    public class EntityIUserEventQuestDailyGroupCompleteReward
    {
        [Key(0)] // RVA: 0x1FD1D18 Offset: 0x1FD1D18 VA: 0x1FD1D18
        public long UserId { get; set; }
        [Key(1)] // RVA: 0x1FD1D58 Offset: 0x1FD1D58 VA: 0x1FD1D58
        public int LastRewardReceiveEventQuestDailyGroupId { get; set; }
        [Key(2)] // RVA: 0x1FD1D6C Offset: 0x1FD1D6C VA: 0x1FD1D6C
        public long LastRewardReceiveDatetime { get; set; }
        [Key(3)] // RVA: 0x1FD1D80 Offset: 0x1FD1D80 VA: 0x1FD1D80
        public long LatestVersion { get; set; }
	}
}
