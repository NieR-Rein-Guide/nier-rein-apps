using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_quest_bonus_weapon_group")]
    public class EntityMQuestBonusWeaponGroup
    {
        [Key(0)] // RVA: 0x1EA47C4 Offset: 0x1EA47C4 VA: 0x1EA47C4
        public int QuestBonusWeaponGroupId { get; set; } // 0x10
        [Key(1)] // RVA: 0x1EA4804 Offset: 0x1EA4804 VA: 0x1EA4804
        public int WeaponId { get; set; } // 0x14
        [Key(2)] // RVA: 0x1EA4844 Offset: 0x1EA4844 VA: 0x1EA4844
        public int LimitBreakCountLowerLimit { get; set; } // 0x18
        [Key(3)] // RVA: 0x1EA4884 Offset: 0x1EA4884 VA: 0x1EA4884
        public int QuestBonusEffectGroupId { get; set; } // 0x1C
        [Key(4)] // RVA: 0x1EA4898 Offset: 0x1EA4898 VA: 0x1EA4898
        public int QuestBonusTermGroupId { get; set; } // 0x20
	}
}
