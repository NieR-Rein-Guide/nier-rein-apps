using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMCompanionAbilityLevel))]
public class EntityMCompanionAbilityLevel
{
    [Key(0)]
    public int CompanionLevelLowerLimit { get; set; }

    [Key(1)]
    public int AbilityLevel { get; set; }
}
