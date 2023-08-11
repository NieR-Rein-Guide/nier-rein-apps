using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_skill_cooltime_behaviour_on_execute_companion_skill")]
public class EntityMSkillCooltimeBehaviourOnExecuteCompanionSkill
{
    [Key(0)]
    public int SkillCooltimeBehaviourActionId { get; set; }

    [Key(1)]
    public int SkillCooltimeAdvanceValue { get; set; }
}
