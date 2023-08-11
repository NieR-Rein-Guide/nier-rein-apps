using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_parts_level_up_rate_group")]
public class EntityMPartsLevelUpRateGroup
{
    [Key(0)]
    public int PartsLevelUpRateGroupId { get; set; }

    [Key(1)]
    public int LevelLowerLimit { get; set; }

    [Key(2)]
    public int SuccessRatePermil { get; set; }
}
