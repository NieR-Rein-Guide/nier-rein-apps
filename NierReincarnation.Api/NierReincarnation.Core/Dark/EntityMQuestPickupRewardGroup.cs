using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_quest_pickup_reward_group")]
public class EntityMQuestPickupRewardGroup
{
    [Key(0)]
    public int QuestPickupRewardGroupId { get; set; }

    [Key(1)]
    public int SortOrder { get; set; }

    [Key(2)]
    public int BattleDropRewardId { get; set; }
}
