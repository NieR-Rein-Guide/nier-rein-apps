using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_catalog_companion")]
    public class EntityMCatalogCompanion
    {
        [Key(0)] // RVA: 0x1DD6BEC Offset: 0x1DD6BEC VA: 0x1DD6BEC
        public int CompanionId { get; set; } // 0x10
        [Key(1)] // RVA: 0x1DD6C2C Offset: 0x1DD6C2C VA: 0x1DD6C2C
        public int SortOrder { get; set; } // 0x14
        [Key(2)] // RVA: 0x1DD6C40 Offset: 0x1DD6C40 VA: 0x1DD6C40
        public int CatalogTermId { get; set; } // 0x18
	}
}
