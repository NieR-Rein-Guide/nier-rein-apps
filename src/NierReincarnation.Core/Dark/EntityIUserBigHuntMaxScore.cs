using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityIUserBigHuntMaxScore))]
public class EntityIUserBigHuntMaxScore
{
    [Key(0)]
    public long UserId { get; set; }

    [Key(1)]
    public int BigHuntBossId { get; set; }

    [Key(2)]
    public long MaxScore { get; set; }

    [Key(3)]
    public long MaxScoreUpdateDatetime { get; set; }

    [Key(4)]
    public long LatestVersion { get; set; }
}
