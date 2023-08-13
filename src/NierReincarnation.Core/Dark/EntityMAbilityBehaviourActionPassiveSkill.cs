using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_ability_behaviour_action_passive_skill")]
public class EntityMAbilityBehaviourActionPassiveSkill
{
    [Key(0)]
    public int AbilityBehaviourActionId { get; set; }

    [Key(1)]
    public int SkillDetailId { get; set; }
}
