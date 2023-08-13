using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_weapon_story_release_condition_operation")]
public class EntityMWeaponStoryReleaseConditionOperation
{
    [Key(0)]
    public int WeaponStoryReleaseConditionOperationGroupId { get; set; }

    [Key(1)]
    public int SortOrder { get; set; }

    [Key(2)]
    public WeaponStoryReleaseConditionType WeaponStoryReleaseConditionType { get; set; }

    [Key(3)]
    public int ConditionValue { get; set; }
}
