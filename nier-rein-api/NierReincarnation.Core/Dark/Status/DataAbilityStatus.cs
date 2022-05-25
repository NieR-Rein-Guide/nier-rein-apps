using NierReincarnation.Core.Dark.Generated.Type;

namespace NierReincarnation.Core.Dark.Status
{
    public class DataAbilityStatus
    {
        // 0x10
        public AbilityBehaviourStatusChangeType AbilityBehaviourStatusChangeType { get; set; }
        // 0x14
        public AttributeConditionType AttributeConditionType { get; set; }
        // 0x18
        public AbilityBehaviourStatusApplyScopeType ApplyScopeType { get; set; }
        // 0x1C
        public AbilityBehaviourStatusOrganizationConditionType OrganizationConditionType { get; set; }
        // 0x20
        public StatusValue StatusChangeValue { get; set; }
    }
}
