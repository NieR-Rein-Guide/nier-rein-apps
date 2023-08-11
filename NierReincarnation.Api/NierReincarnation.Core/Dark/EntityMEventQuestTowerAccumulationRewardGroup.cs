using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_event_quest_tower_accumulation_reward_group")]
public class EntityMEventQuestTowerAccumulationRewardGroup
{
    [Key(0)]
    public int EventQuestTowerAccumulationRewardGroupId { get; set; }

    [Key(1)]
    public int QuestMissionClearCount { get; set; }

    [Key(2)]
    public int EventQuestTowerRewardGroupId { get; set; }
}
