using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_ability_behaviour_action_status")]
public class EntityMAbilityBehaviourActionStatus
{
    [Key(0)] // RVA: 0x1DD63C8 Offset: 0x1DD63C8 VA: 0x1DD63C8
    public int AbilityBehaviourActionId { get; set; }

    [Key(1)] // RVA: 0x1DD6408 Offset: 0x1DD6408 VA: 0x1DD6408
    public AbilityBehaviourStatusChangeType AbilityBehaviourStatusChangeType { get; set; }

    [Key(2)] // RVA: 0x1DD641C Offset: 0x1DD641C VA: 0x1DD641C
    public AttributeConditionType AttributeConditionType { get; set; }

    [Key(3)] // RVA: 0x1DD6430 Offset: 0x1DD6430 VA: 0x1DD6430
    public AbilityBehaviourStatusOrganizationConditionType AbilityOrganizationConditionType { get; set; }

    [Key(4)] // RVA: 0x1DD6444 Offset: 0x1DD6444 VA: 0x1DD6444
    public int AbilityStatusId { get; set; }

    [Key(5)] // RVA: 0x1DD6458 Offset: 0x1DD6458 VA: 0x1DD6458
    public AbilityBehaviourStatusApplyScopeType ApplyScopeType { get; set; }
}
