using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_big_hunt_boss_quest_group")]
    public class EntityMBigHuntBossQuestGroup
    {
        [Key(0)]
        public int BigHuntBossQuestGroupId { get; set; } // 0x10
        [Key(1)]
        public int SortOrder { get; set; } // 0x14
        [Key(2)]
        public int BigHuntBossQuestId { get; set; } // 0x18
    }
}