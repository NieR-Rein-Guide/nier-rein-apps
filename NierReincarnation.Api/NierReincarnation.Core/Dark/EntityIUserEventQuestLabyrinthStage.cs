using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_event_quest_labyrinth_stage")]
    public class EntityIUserEventQuestLabyrinthStage
    {
        [Key(0)]
        public long UserId { get; set; } // 0x10

        [Key(1)]
        public int EventQuestChapterId { get; set; } // 0x18

        [Key(2)]
        public int StageOrder { get; set; } // 0x1C

        [Key(3)]
        public bool IsReceivedStageClearReward { get; set; } // 0x20

        [Key(4)]
        public int AccumulationRewardReceivedQuestMissionCount { get; set; } // 0x24

        [Key(5)]
        public long LatestVersion { get; set; } // 0x28
    }
}
