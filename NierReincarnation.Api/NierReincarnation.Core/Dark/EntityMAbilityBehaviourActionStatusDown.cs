using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_ability_behaviour_action_status_down")]
    public class EntityMAbilityBehaviourActionStatusDown
    {
        [Key(0)]
        public int AbilityBehaviourActionId { get; set; } // 0x10

        [Key(1)]
        public AbilityBehaviourStatusChangeType AbilityBehaviourStatusChangeType { get; set; } // 0x14

        [Key(2)]
        public AttributeConditionType AttributeConditionType { get; set; } // 0x18

        [Key(3)]
        public AbilityBehaviourStatusOrganizationConditionType AbilityOrganizationConditionType { get; set; } // 0x1C

        [Key(4)]
        public int AbilityStatusId { get; set; } // 0x20

        [Key(5)]
        public AbilityBehaviourStatusApplyScopeType ApplyScopeType { get; set; } // 0x24
    }
}
