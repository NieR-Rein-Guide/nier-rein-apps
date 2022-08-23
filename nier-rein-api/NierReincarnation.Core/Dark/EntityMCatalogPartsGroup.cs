using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_catalog_parts_group")]
    public class EntityMCatalogPartsGroup
    {
        [Key(0)] // RVA: 0x1DD6CBC Offset: 0x1DD6CBC VA: 0x1DD6CBC
        public int PartsGroupId { get; set; } // 0x10
        [Key(1)] // RVA: 0x1DD6CFC Offset: 0x1DD6CFC VA: 0x1DD6CFC
        public int SortOrder { get; set; } // 0x14
        [Key(2)] // RVA: 0x1DD6D10 Offset: 0x1DD6D10 VA: 0x1DD6D10
        public int CatalogTermId { get; set; } // 0x18
	}
}
