using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_quest_bonus_effect_group")]
    public class EntityMQuestBonusEffectGroup
    {
        [Key(0)]
        public int QuestBonusEffectGroupId { get; set; } // 0x10
        [Key(1)]
        public int SortOrder { get; set; } // 0x14
        [Key(2)]
        public int QuestBonusType { get; set; } // 0x18
        [Key(3)]
        public int QuestBonusEffectId { get; set; } // 0x1C
    }
}