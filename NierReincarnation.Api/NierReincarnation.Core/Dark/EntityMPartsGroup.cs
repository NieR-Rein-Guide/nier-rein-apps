using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_parts_group")]
    public class EntityMPartsGroup
    {
        [Key(0)] // RVA: 0x1DE0364 Offset: 0x1DE0364 VA: 0x1DE0364
        public int PartsGroupId { get; set; } // 0x10
        [Key(1)] // RVA: 0x1DE03A4 Offset: 0x1DE03A4 VA: 0x1DE03A4
        public int PartsSeriesId { get; set; } // 0x14
        [Key(2)] // RVA: 0x1DE03B8 Offset: 0x1DE03B8 VA: 0x1DE03B8
        public int SortOrder { get; set; } // 0x18
        [Key(3)] // RVA: 0x1DE03CC Offset: 0x1DE03CC VA: 0x1DE03CC
        public int PartsGroupAssetId { get; set; } // 0x1C
	}
}
