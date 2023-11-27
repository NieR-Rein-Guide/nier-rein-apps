using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityIUserLoginBonus))]
public class EntityIUserLoginBonus
{
    [Key(0)]
    public long UserId { get; set; }

    [Key(1)]
    public int LoginBonusId { get; set; }

    [Key(2)]
    public int CurrentPageNumber { get; set; }

    [Key(3)]
    public int CurrentStampNumber { get; set; }

    [Key(4)]
    public long LatestRewardReceiveDatetime { get; set; }

    [Key(5)]
    public long LatestVersion { get; set; }
}
