using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_weapon_story_release_condition_group")]
    public class EntityMWeaponStoryReleaseConditionGroup
    {
        [Key(0)]
        public int WeaponStoryReleaseConditionGroupId { get; set; } // 0x10

        [Key(1)]
        public int StoryIndex { get; set; } // 0x14

        [Key(2)]
        public WeaponStoryReleaseConditionType WeaponStoryReleaseConditionType { get; set; } // 0x18

        [Key(3)]
        public int ConditionValue { get; set; } // 0x1C

        [Key(4)]
        public int WeaponStoryReleaseConditionOperationGroupId { get; set; } // 0x20
    }
}
