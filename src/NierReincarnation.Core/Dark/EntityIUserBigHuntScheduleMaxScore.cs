using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityIUserBigHuntScheduleMaxScore))]
public class EntityIUserBigHuntScheduleMaxScore
{
    [Key(0)]
    public long UserId { get; set; }

    [Key(1)]
    public int BigHuntScheduleId { get; set; }

    [Key(2)]
    public int BigHuntBossId { get; set; }

    [Key(3)]
    public long MaxScore { get; set; }

    [Key(4)]
    public long MaxScoreUpdateDatetime { get; set; }

    [Key(5)]
    public long LatestVersion { get; set; }
}
