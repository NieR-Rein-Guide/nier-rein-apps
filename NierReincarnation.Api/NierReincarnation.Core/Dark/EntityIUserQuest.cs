using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_quest")]
    public class EntityIUserQuest
    {
        [Key(0)]
        public long UserId { get; set; } // 0x10

        [Key(1)]
        public int QuestId { get; set; } // 0x18

        [Key(2)]
        public int QuestStateType { get; set; } // 0x1C

        [Key(3)]
        public bool IsBattleOnly { get; set; } // 0x20

        [Key(4)]
        public long LatestStartDatetime { get; set; } // 0x28

        [Key(5)]
        public int ClearCount { get; set; } // 0x30

        [Key(6)]
        public int DailyClearCount { get; set; } // 0x34

        [Key(7)]
        public long LastClearDatetime { get; set; } // 0x38

        [Key(8)]
        public int ShortestClearFrames { get; set; } // 0x40

        [Key(9)]
        public long LatestVersion { get; set; } // 0x48
    }
}
