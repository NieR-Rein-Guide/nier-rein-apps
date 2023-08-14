using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_parts_level_up_price_group")]
public class EntityMPartsLevelUpPriceGroup
{
    [Key(0)]
    public int PartsLevelUpPriceGroupId { get; set; }

    [Key(1)]
    public int LevelLowerLimit { get; set; }

    [Key(2)]
    public int Gold { get; set; }
}
