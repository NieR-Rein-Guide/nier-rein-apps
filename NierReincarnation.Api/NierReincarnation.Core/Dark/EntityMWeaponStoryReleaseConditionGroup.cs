using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_weapon_story_release_condition_group")]
public class EntityMWeaponStoryReleaseConditionGroup
{
    [Key(0)]
    public int WeaponStoryReleaseConditionGroupId { get; set; }

    [Key(1)]
    public int StoryIndex { get; set; }

    [Key(2)]
    public WeaponStoryReleaseConditionType WeaponStoryReleaseConditionType { get; set; }

    [Key(3)]
    public int ConditionValue { get; set; }

    [Key(4)]
    public int WeaponStoryReleaseConditionOperationGroupId { get; set; }
}
