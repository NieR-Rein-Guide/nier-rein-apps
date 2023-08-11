using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_catalog_costume")]
    public class EntityMCatalogCostume
    {
        [Key(0)] // RVA: 0x1DD6C54 Offset: 0x1DD6C54 VA: 0x1DD6C54
        public int CostumeId { get; set; }

        [Key(1)] // RVA: 0x1DD6C94 Offset: 0x1DD6C94 VA: 0x1DD6C94
        public int SortOrder { get; set; }

        [Key(2)] // RVA: 0x1DD6CA8 Offset: 0x1DD6CA8 VA: 0x1DD6CA8
        public int CatalogTermId { get; set; }
    }
}
