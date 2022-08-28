using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_quest_bonus_costume_group")]
    public class EntityMQuestBonusCostumeGroup
    {
        [Key(0)]
        public int QuestBonusCostumeGroupId { get; set; } // 0x10
        [Key(1)]
        public int CostumeId { get; set; } // 0x14
        [Key(2)]
        public int QuestBonusEffectGroupId { get; set; } // 0x18
        [Key(3)]
        public int QuestBonusTermGroupId { get; set; } // 0x1C
    }
}