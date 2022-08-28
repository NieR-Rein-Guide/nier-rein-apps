using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_explore_group")]
    public class EntityMExploreGroup
    {
        [Key(0)]
        public int ExploreGroupId { get; set; } // 0x10
        [Key(1)]
        public int DifficultyType { get; set; } // 0x14
        [Key(2)]
        public int ExploreId { get; set; } // 0x18
    }
}