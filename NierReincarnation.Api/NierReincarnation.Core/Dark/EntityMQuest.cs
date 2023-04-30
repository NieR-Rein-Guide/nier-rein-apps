using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_quest")]
    public class EntityMQuest
    {
        [Key(0)] // RVA: 0x1DDDEF4 Offset: 0x1DDDEF4 VA: 0x1DDDEF4
        public int QuestId { get; set; } // 0x10

        [Key(1)] // RVA: 0x1DDDF34 Offset: 0x1DDDF34 VA: 0x1DDDF34
        public int NameQuestTextId { get; set; } // 0x14

        [Key(2)] // RVA: 0x1DDDF48 Offset: 0x1DDDF48 VA: 0x1DDDF48
        public int PictureBookNameQuestTextId { get; set; } // 0x18

        [Key(3)] // RVA: 0x1DDDF5C Offset: 0x1DDDF5C VA: 0x1DDDF5C
        public int QuestReleaseConditionListId { get; set; } // 0x1C

        [Key(4)] // RVA: 0x1DDDF70 Offset: 0x1DDDF70 VA: 0x1DDDF70
        public int StoryQuestTextId { get; set; } // 0x20

        [Key(5)] // RVA: 0x1DDDF84 Offset: 0x1DDDF84 VA: 0x1DDDF84
        public int QuestDisplayAttributeGroupId { get; set; } // 0x24

        [Key(6)] // RVA: 0x1DDDF98 Offset: 0x1DDDF98 VA: 0x1DDDF98
        public int RecommendedDeckPower { get; set; } // 0x28

        [Key(7)] // RVA: 0x1DDDFAC Offset: 0x1DDDFAC VA: 0x1DDDFAC
        public int QuestFirstClearRewardGroupId { get; set; } // 0x2C

        [Key(8)] // RVA: 0x1DDDFC0 Offset: 0x1DDDFC0 VA: 0x1DDDFC0
        public int QuestPickupRewardGroupId { get; set; } // 0x30

        [Key(9)] // RVA: 0x1DDDFD4 Offset: 0x1DDDFD4 VA: 0x1DDDFD4
        public int QuestDeckRestrictionGroupId { get; set; } // 0x34

        [Key(10)] // RVA: 0x1DDDFE8 Offset: 0x1DDDFE8 VA: 0x1DDDFE8
        public int QuestMissionGroupId { get; set; } // 0x38

        [Key(11)] // RVA: 0x1DDDFFC Offset: 0x1DDDFFC VA: 0x1DDDFFC
        public int Stamina { get; set; } // 0x3C

        [Key(12)] // RVA: 0x1DDE010 Offset: 0x1DDE010 VA: 0x1DDE010
        public int UserExp { get; set; } // 0x40

        [Key(13)] // RVA: 0x1DDE024 Offset: 0x1DDE024 VA: 0x1DDE024
        public int CharacterExp { get; set; } // 0x44

        [Key(14)] // RVA: 0x1DDE038 Offset: 0x1DDE038 VA: 0x1DDE038
        public int CostumeExp { get; set; } // 0x48

        [Key(15)] // RVA: 0x1DDE04C Offset: 0x1DDE04C VA: 0x1DDE04C
        public int Gold { get; set; } // 0x4C

        [Key(16)] // RVA: 0x1DDE060 Offset: 0x1DDE060 VA: 0x1DDE060
        public int DailyClearableCount { get; set; } // 0x50

        [Key(17)] // RVA: 0x1DDE074 Offset: 0x1DDE074 VA: 0x1DDE074
        public bool IsRunInTheBackground { get; set; } // 0x54

        [Key(18)] // RVA: 0x1DDE088 Offset: 0x1DDE088 VA: 0x1DDE088
        public bool IsCountedAsQuest { get; set; } // 0x55

        [Key(19)] // RVA: 0x1DDE09C Offset: 0x1DDE09C VA: 0x1DDE09C
        public int QuestBonusId { get; set; } // 0x58

        [Key(20)] // RVA: 0x1DDE0B0 Offset: 0x1DDE0B0 VA: 0x1DDE0B0
        public bool IsNotShowAfterClear { get; set; } // 0x5C

        [Key(21)] // RVA: 0x1DDE0C4 Offset: 0x1DDE0C4 VA: 0x1DDE0C4
        public bool IsBigWinTarget { get; set; } // 0x5D

        [Key(22)] // RVA: 0x1DDE0D8 Offset: 0x1DDE0D8 VA: 0x1DDE0D8
        public bool IsUsableSkipTicket { get; set; } // 0x5E

        [Key(23)] // RVA: 0x1DDE0EC Offset: 0x1DDE0EC VA: 0x1DDE0EC
        public int QuestReplayFlowRewardGroupId { get; set; } // 0x60

        [Key(24)] // RVA: 0x1DDE100 Offset: 0x1DDE100 VA: 0x1DDE100
        public int InvisibleQuestMissionGroupId { get; set; } // 0x64

        [Key(25)] // RVA: 0x1F7CE24 Offset: 0x1F7CE24 VA: 0x1F7CE24
        public int FieldEffectGroupId { get; set; } // 0x68
    }
}
