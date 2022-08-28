using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_weapon_story_release_condition_operation_group")]
    public class EntityMWeaponStoryReleaseConditionOperationGroup
    {
        [Key(0)]
        public int WeaponStoryReleaseConditionOperationGroupId { get; set; } // 0x10
        [Key(1)]
        public int ConditionOperationType { get; set; } // 0x14
    }
}