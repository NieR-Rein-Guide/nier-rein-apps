using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_mission_group")]
    public class EntityMMissionGroup
    {
        [Key(0)]
        public int MissionGroupId { get; set; } // 0x10
        [Key(1)]
        public int MissionCategoryType { get; set; } // 0x14
        [Key(2)]
        public int LabelMissionTextId { get; set; } // 0x18
        [Key(3)]
        public int SortOrderInLabel { get; set; } // 0x1C
        [Key(4)]
        public int AssetId { get; set; } // 0x20
        [Key(5)]
        public int MissionGroupUnlockConditionGroupId { get; set; } // 0x24
    }
}