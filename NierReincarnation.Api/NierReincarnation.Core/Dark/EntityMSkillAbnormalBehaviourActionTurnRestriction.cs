using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_skill_abnormal_behaviour_action_turn_restriction")]
public class EntityMSkillAbnormalBehaviourActionTurnRestriction
{
    [Key(0)]
    public int SkillBehaviourActionId { get; set; }

    [Key(1)]
    public int TurnRestrictionProbabilityPermil { get; set; }

    [Key(2)]
    public AbnormalBehaviourTurnRestrictionSkillType AbnormalBehaviourTurnRestrictionSkillType { get; set; }
}
