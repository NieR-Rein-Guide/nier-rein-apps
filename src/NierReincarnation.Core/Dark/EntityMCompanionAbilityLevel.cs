using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_companion_ability_level")]
public class EntityMCompanionAbilityLevel
{
    [Key(0)]
    public int CompanionLevelLowerLimit { get; set; }

    [Key(1)]
    public int AbilityLevel { get; set; }
}
