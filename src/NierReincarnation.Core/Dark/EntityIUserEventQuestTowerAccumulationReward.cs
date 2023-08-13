using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("i_user_event_quest_tower_accumulation_reward")]
public class EntityIUserEventQuestTowerAccumulationReward
{
    [Key(0)]
    public long UserId { get; set; }

    [Key(1)]
    public int EventQuestChapterId { get; set; }

    [Key(2)]
    public int LatestRewardReceiveQuestMissionClearCount { get; set; }

    [Key(3)]
    public long LatestVersion { get; set; }
}
