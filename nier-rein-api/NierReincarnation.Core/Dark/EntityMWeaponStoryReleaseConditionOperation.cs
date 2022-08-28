using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_weapon_story_release_condition_operation")]
    public class EntityMWeaponStoryReleaseConditionOperation
    {
        [Key(0)]
        public int WeaponStoryReleaseConditionOperationGroupId { get; set; } // 0x10
        [Key(1)]
        public int SortOrder { get; set; } // 0x14
        [Key(2)]
        public int WeaponStoryReleaseConditionType { get; set; } // 0x18
        [Key(3)]
        public int ConditionValue { get; set; } // 0x1C
    }
}