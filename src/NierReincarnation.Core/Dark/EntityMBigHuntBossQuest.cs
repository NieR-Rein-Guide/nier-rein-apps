using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_big_hunt_boss_quest")]
public class EntityMBigHuntBossQuest
{
    [Key(0)]
    public int BigHuntBossQuestId { get; set; }

    [Key(1)]
    public int BigHuntBossId { get; set; }

    [Key(2)]
    public int BigHuntQuestGroupId { get; set; }

    [Key(3)]
    public int BigHuntBossQuestScoreCoefficientId { get; set; }

    [Key(4)]
    public int BigHuntScoreRewardGroupScheduleId { get; set; }

    [Key(5)]
    public int BigHuntLinkId { get; set; }

    [Key(6)]
    public int DailyChallengeCount { get; set; }
}
