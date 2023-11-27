using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMCompanionSkillLevel))]
public class EntityMCompanionSkillLevel
{
    [Key(0)]
    public int CompanionLevelLowerLimit { get; set; }

    [Key(1)]
    public int SkillLevel { get; set; }
}
