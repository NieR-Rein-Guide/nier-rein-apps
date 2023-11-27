using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMPartsSeriesBonusAbilityGroup))]
public class EntityMPartsSeriesBonusAbilityGroup
{
    [Key(0)]
    public int PartsSeriesBonusAbilityGroupId { get; set; }

    [Key(1)]
    public int SetCount { get; set; }

    [Key(2)]
    public int AbilityId { get; set; }

    [Key(3)]
    public int AbilityLevel { get; set; }
}
