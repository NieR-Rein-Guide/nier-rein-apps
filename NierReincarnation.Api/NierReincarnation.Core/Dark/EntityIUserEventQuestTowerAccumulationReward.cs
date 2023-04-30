using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_event_quest_tower_accumulation_reward")]
    public class EntityIUserEventQuestTowerAccumulationReward
    {
        [Key(0)]
        public long UserId { get; set; } // 0x10

        [Key(1)]
        public int EventQuestChapterId { get; set; } // 0x18

        [Key(2)]
        public int LatestRewardReceiveQuestMissionClearCount { get; set; } // 0x1C

        [Key(3)]
        public long LatestVersion { get; set; } // 0x20
    }
}
