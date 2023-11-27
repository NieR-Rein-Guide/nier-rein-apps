using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMWeaponStoryReleaseConditionOperationGroup))]
public class EntityMWeaponStoryReleaseConditionOperationGroup
{
    [Key(0)]
    public int WeaponStoryReleaseConditionOperationGroupId { get; set; }

    [Key(1)]
    public ConditionOperationType ConditionOperationType { get; set; }
}
