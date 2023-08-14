using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("i_user_event_quest_labyrinth_stage")]
public class EntityIUserEventQuestLabyrinthStage
{
    [Key(0)]
    public long UserId { get; set; }

    [Key(1)]
    public int EventQuestChapterId { get; set; }

    [Key(2)]
    public int StageOrder { get; set; }

    [Key(3)]
    public bool IsReceivedStageClearReward { get; set; }

    [Key(4)]
    public int AccumulationRewardReceivedQuestMissionCount { get; set; }

    [Key(5)]
    public long LatestVersion { get; set; }
}
