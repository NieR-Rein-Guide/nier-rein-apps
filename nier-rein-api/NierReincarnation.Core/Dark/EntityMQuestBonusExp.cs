using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_quest_bonus_exp")]
    public class EntityMQuestBonusExp
    {
        [Key(0)]
        public int QuestBonusEffectId { get; set; } // 0x10
        [Key(1)]
        public int ExpType { get; set; } // 0x14
        [Key(2)]
        public int BonusValuePermil { get; set; } // 0x18
    }
}