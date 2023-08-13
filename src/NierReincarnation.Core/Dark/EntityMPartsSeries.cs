using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_parts_series")]
public class EntityMPartsSeries
{
    [Key(0)]
    public int PartsSeriesId { get; set; }

    [Key(1)]
    public int PartsSeriesBonusAbilityGroupId { get; set; }

    [Key(2)]
    public int PartsSeriesAssetId { get; set; }

    [Key(3)]
    public long ListSettingDisplayStartDatetime { get; set; }
}
