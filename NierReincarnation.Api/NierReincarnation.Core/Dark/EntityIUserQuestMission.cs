using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_quest_mission")]
    public class EntityIUserQuestMission
    {
        [Key(0)]
        public long UserId { get; set; } // 0x10

        [Key(1)]
        public int QuestId { get; set; } // 0x18

        [Key(2)]
        public int QuestMissionId { get; set; } // 0x1C

        [Key(3)]
        public int ProgressValue { get; set; } // 0x20

        [Key(4)]
        public bool IsClear { get; set; } // 0x24

        [Key(5)]
        public long LatestClearDatetime { get; set; } // 0x28

        [Key(6)]
        public long LatestVersion { get; set; } // 0x30
    }
}
