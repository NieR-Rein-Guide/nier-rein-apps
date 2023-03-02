using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_catalog_thought")]
    public class EntityMCatalogThought
    {
        [Key(0)] // RVA: 0x1E9BEB4 Offset: 0x1E9BEB4 VA: 0x1E9BEB4
        public int ThoughtId { get; set; } // 0x10
        [Key(1)] // RVA: 0x1E9BEF4 Offset: 0x1E9BEF4 VA: 0x1E9BEF4
        public int SortOrder { get; set; } // 0x14
        [Key(2)] // RVA: 0x1E9BF08 Offset: 0x1E9BF08 VA: 0x1E9BF08
        public int CatalogTermId { get; set; } // 0x18
	}
}
