using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityIUserMissionPassPoint))]
public class EntityIUserMissionPassPoint
{
    [Key(0)]
    public long UserId { get; set; }

    [Key(1)]
    public int MissionPassId { get; set; }

    [Key(2)]
    public int Point { get; set; }

    [Key(3)]
    public int PremiumRewardReceivedLevel { get; set; }

    [Key(4)]
    public int NoPremiumRewardReceivedLevel { get; set; }

    [Key(5)]
    public long LatestVersion { get; set; }
}
