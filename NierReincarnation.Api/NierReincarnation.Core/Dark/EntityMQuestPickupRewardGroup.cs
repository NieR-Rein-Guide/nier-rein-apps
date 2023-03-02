using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_quest_pickup_reward_group")]
    public class EntityMQuestPickupRewardGroup
    {
        [Key(0)]
        public int QuestPickupRewardGroupId { get; set; } // 0x10
        [Key(1)]
        public int SortOrder { get; set; } // 0x14
        [Key(2)]
        public int BattleDropRewardId { get; set; } // 0x18
    }
}