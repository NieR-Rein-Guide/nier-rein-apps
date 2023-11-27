using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityIUserBigHuntWeeklyMaxScore))]
public class EntityIUserBigHuntWeeklyMaxScore
{
    [Key(0)]
    public long UserId { get; set; }

    [Key(1)]
    public long BigHuntWeeklyVersion { get; set; }

    [Key(2)]
    public AttributeType AttributeType { get; set; }

    [Key(3)]
    public long MaxScore { get; set; }

    [Key(4)]
    public long LatestVersion { get; set; }
}
