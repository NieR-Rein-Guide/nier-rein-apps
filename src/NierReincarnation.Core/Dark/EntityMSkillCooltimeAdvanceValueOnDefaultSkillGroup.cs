using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_skill_cooltime_advance_value_on_default_skill_group")]
public class EntityMSkillCooltimeAdvanceValueOnDefaultSkillGroup
{
    [Key(0)]
    public int SkillCooltimeAdvanceValueOnDefaultSkillGroupId { get; set; }

    [Key(1)]
    public int SkillHitCountLowerLimit { get; set; }

    [Key(2)]
    public int SkillCooltimeAdvanceValue { get; set; }
}
