using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityIUserBigHuntStatus))]
public class EntityIUserBigHuntStatus
{
    [Key(0)]
    public long UserId { get; set; }

    [Key(1)]
    public int BigHuntBossQuestId { get; set; }

    [Key(2)]
    public int DailyChallengeCount { get; set; }

    [Key(3)]
    public long LatestChallengeDatetime { get; set; }

    [Key(4)]
    public long LatestVersion { get; set; }
}
