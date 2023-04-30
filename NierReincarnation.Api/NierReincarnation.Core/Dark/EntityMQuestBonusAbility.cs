using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_quest_bonus_ability")]
    public class EntityMQuestBonusAbility
    {
        [Key(0)]
        public int QuestBonusEffectId { get; set; } // 0x10

        [Key(1)]
        public int AbilityId { get; set; } // 0x14

        [Key(2)]
        public int Level { get; set; } // 0x18
    }
}
