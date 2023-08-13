using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_skill_cooltime_behaviour_on_execute_default_skill")]
public class EntityMSkillCooltimeBehaviourOnExecuteDefaultSkill
{
    [Key(0)]
    public int SkillCooltimeBehaviourActionId { get; set; }

    [Key(1)]
    public int SkillCooltimeAdvanceValueOnDefaultSkillGroupId { get; set; }
}
