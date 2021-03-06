using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_parts_series")]
    public class EntityMPartsSeries
    {
        [Key(0)] // RVA: 0x1DE0584 Offset: 0x1DE0584 VA: 0x1DE0584
        public int PartsSeriesId { get; set; }
        [Key(1)] // RVA: 0x1DE05C4 Offset: 0x1DE05C4 VA: 0x1DE05C4
        public int PartsSeriesBonusAbilityGroupId { get; set; }
        [Key(2)] // RVA: 0x1DE05D8 Offset: 0x1DE05D8 VA: 0x1DE05D8
        public int PartsSeriesAssetId { get; set; }
    }
}
