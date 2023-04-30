using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_mission")]
    public class EntityMMission
    {
        [Key(0)]
        public int MissionId { get; set; } // 0x10

        [Key(1)]
        public int MissionGroupId { get; set; } // 0x14

        [Key(2)]
        public int SortOrderInMissionGroup { get; set; } // 0x18

        [Key(3)]
        public int MissionUnlockConditionId { get; set; } // 0x1C

        [Key(4)]
        public bool IsNotShowBeforeClear { get; set; } // 0x20

        [Key(5)]
        public int NameMissionTextId { get; set; } // 0x24

        [Key(6)]
        public int MissionLinkId { get; set; } // 0x28

        [Key(7)]
        public MissionClearConditionType MissionClearConditionType { get; set; } // 0x2C

        [Key(8)]
        public int MissionClearConditionGroupId { get; set; } // 0x30

        [Key(9)]
        public int ClearConditionValue { get; set; } // 0x34

        [Key(10)]
        public int MissionClearConditionOptionGroupId { get; set; } // 0x38

        [Key(11)]
        public int MissionRewardId { get; set; } // 0x3C

        [Key(12)]
        public int MissionTermId { get; set; } // 0x40

        [Key(13)]
        public int MinExpirationDays { get; set; } // 0x44

        [Key(14)]
        public MainFunctionType RelatedMainFunctionType { get; set; } // 0x48

        [Key(15)]
        public int MissionClearConditionOptionDetailGroupId { get; set; } // 0x4C

        [Key(16)]
        public int MissionUnlockConditionDetailGroupId { get; set; } // 0x50
    }
}
