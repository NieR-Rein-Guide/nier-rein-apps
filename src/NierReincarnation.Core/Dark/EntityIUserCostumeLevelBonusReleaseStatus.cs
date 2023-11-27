using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityIUserCostumeLevelBonusReleaseStatus))]
public class EntityIUserCostumeLevelBonusReleaseStatus
{
    [Key(0)]
    public long UserId { get; set; }

    [Key(1)]
    public int CostumeId { get; set; }

    [Key(2)]
    public int LastReleasedBonusLevel { get; set; }

    [Key(3)]
    public int ConfirmedBonusLevel { get; set; }

    [Key(4)]
    public long LatestVersion { get; set; }
}
