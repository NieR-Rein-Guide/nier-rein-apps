using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_quest_bonus_character_group")]
    public class EntityMQuestBonusCharacterGroup
    {
        [Key(0)] // RVA: 0x1EA4330 Offset: 0x1EA4330 VA: 0x1EA4330
        public int QuestBonusCharacterGroupId { get; set; } // 0x10

        [Key(1)] // RVA: 0x1EA4370 Offset: 0x1EA4370 VA: 0x1EA4370
        public int CharacterId { get; set; } // 0x14

        [Key(2)] // RVA: 0x1EA43B0 Offset: 0x1EA43B0 VA: 0x1EA43B0
        public int QuestBonusEffectGroupId { get; set; } // 0x18

        [Key(3)] // RVA: 0x1EA43C4 Offset: 0x1EA43C4 VA: 0x1EA43C4
        public int QuestBonusTermGroupId { get; set; } // 0x1C
    }
}
