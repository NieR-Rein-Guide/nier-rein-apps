using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_ability_behaviour_action_status_down")]
public class EntityMAbilityBehaviourActionStatusDown
{
    [Key(0)]
    public int AbilityBehaviourActionId { get; set; }

    [Key(1)]
    public AbilityBehaviourStatusChangeType AbilityBehaviourStatusChangeType { get; set; }

    [Key(2)]
    public AttributeConditionType AttributeConditionType { get; set; }

    [Key(3)]
    public AbilityBehaviourStatusOrganizationConditionType AbilityOrganizationConditionType { get; set; }

    [Key(4)]
    public int AbilityStatusId { get; set; }

    [Key(5)]
    public AbilityBehaviourStatusApplyScopeType ApplyScopeType { get; set; }
}
