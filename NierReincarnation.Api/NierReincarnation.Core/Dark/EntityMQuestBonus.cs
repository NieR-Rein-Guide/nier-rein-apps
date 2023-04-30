using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_quest_bonus")]
    public class EntityMQuestBonus
    {
        [Key(0)] // RVA: 0x1EA4238 Offset: 0x1EA4238 VA: 0x1EA4238
        public int QuestBonusId { get; set; } // 0x10

        [Key(1)] // RVA: 0x1EA4278 Offset: 0x1EA4278 VA: 0x1EA4278
        public int QuestBonusCharacterGroupId { get; set; } // 0x14

        [Key(2)] // RVA: 0x1EA428C Offset: 0x1EA428C VA: 0x1EA428C
        public int QuestBonusCostumeGroupId { get; set; } // 0x18

        [Key(3)] // RVA: 0x1EA42A0 Offset: 0x1EA42A0 VA: 0x1EA42A0
        public int QuestBonusWeaponGroupId { get; set; } // 0x1C

        [Key(4)] // RVA: 0x1EA42B4 Offset: 0x1EA42B4 VA: 0x1EA42B4
        public int QuestBonusCostumeSettingGroupId { get; set; } // 0x20

        [Key(5)]
        public int QuestBonusAllyCharacterId { get; set; } // 0x24
    }
}
