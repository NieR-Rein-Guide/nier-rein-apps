using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMPartsLevelUpRateGroup))]
public class EntityMPartsLevelUpRateGroup
{
    [Key(0)]
    public int PartsLevelUpRateGroupId { get; set; }

    [Key(1)]
    public int LevelLowerLimit { get; set; }

    [Key(2)]
    public int SuccessRatePermil { get; set; }
}
