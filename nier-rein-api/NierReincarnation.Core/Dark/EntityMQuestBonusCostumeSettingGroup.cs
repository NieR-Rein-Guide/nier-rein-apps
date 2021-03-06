using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_quest_bonus_costume_setting_group")]
    public class EntityMQuestBonusCostumeSettingGroup
    {
        [Key(0)] // RVA: 0x1EA4480 Offset: 0x1EA4480 VA: 0x1EA4480
        public int QuestBonusCostumeSettingGroupId { get; set; }
        [Key(1)] // RVA: 0x1EA44C0 Offset: 0x1EA44C0 VA: 0x1EA44C0
        public int CostumeId { get; set; }
        [Key(2)] // RVA: 0x1EA4500 Offset: 0x1EA4500 VA: 0x1EA4500
        public int LimitBreakCountLowerLimit { get; set; }
        [Key(3)] // RVA: 0x1EA4540 Offset: 0x1EA4540 VA: 0x1EA4540
        public int QuestBonusEffectGroupId { get; set; }
        [Key(4)] // RVA: 0x1EA4554 Offset: 0x1EA4554 VA: 0x1EA4554
        public int QuestBonusTermGroupId { get; set; }
	}
}
