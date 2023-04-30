using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_quest_auto_orbit")]
    public class EntityIUserQuestAutoOrbit
    {
        [Key(0)]
        public long UserId { get; set; } // 0x10

        [Key(1)]
        public QuestType QuestType { get; set; } // 0x18

        [Key(2)]
        public int ChapterId { get; set; } // 0x1C

        [Key(3)]
        public int QuestId { get; set; } // 0x20

        [Key(4)]
        public int MaxAutoOrbitCount { get; set; } // 0x24

        [Key(5)]
        public int ClearedAutoOrbitCount { get; set; } // 0x28

        [Key(6)]
        public long LastClearDatetime { get; set; } // 0x30

        [Key(7)]
        public long LatestVersion { get; set; } // 0x38
    }
}
