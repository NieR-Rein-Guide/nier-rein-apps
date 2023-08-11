using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_companion_skill_level")]
public class EntityMCompanionSkillLevel
{
    [Key(0)] // RVA: 0x1DDB894 Offset: 0x1DDB894 VA: 0x1DDB894
    public int CompanionLevelLowerLimit { get; set; }

    [Key(1)] // RVA: 0x1DDB8D4 Offset: 0x1DDB8D4 VA: 0x1DDB8D4
    public int SkillLevel { get; set; }
}
