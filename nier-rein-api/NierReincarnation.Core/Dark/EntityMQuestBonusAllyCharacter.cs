using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_quest_bonus_ally_character")]
    public class EntityMQuestBonusAllyCharacter
    {
        [Key(0)]
        public int QuestBonusAllyCharacterId { get; set; } // 0x10
        [Key(1)]
        public int QuestBonusEffectGroupId { get; set; } // 0x14
        [Key(2)]
        public int QuestBonusTermGroupId { get; set; } // 0x18
    }
}