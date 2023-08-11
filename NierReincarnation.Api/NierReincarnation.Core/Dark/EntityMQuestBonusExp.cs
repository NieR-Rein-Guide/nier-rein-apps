using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_quest_bonus_exp")]
    public class EntityMQuestBonusExp
    {
        [Key(0)]
        public int QuestBonusEffectId { get; set; }

        [Key(1)]
        public int ExpType { get; set; }

        [Key(2)]
        public int BonusValuePermil { get; set; }
    }
}
