using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_cage_memory")]
    public class EntityMCageMemory
    {
        [Key(0)]
        public int CageMemoryId { get; set; } // 0x10

        [Key(1)]
        public int MainQuestSeasonId { get; set; } // 0x14

        [Key(2)]
        public int SortOrder { get; set; } // 0x18

        [Key(3)]
        public int CageMemoryAssetId { get; set; } // 0x1C
    }
}
