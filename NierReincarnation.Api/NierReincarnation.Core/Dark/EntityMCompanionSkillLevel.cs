using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_companion_skill_level")]
public class EntityMCompanionSkillLevel
{
    [Key(0)]
    public int CompanionLevelLowerLimit { get; set; }

    [Key(1)]
    public int SkillLevel { get; set; }
}
