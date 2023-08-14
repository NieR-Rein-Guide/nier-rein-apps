using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("i_user_premium_item")]
public class EntityIUserPremiumItem
{
    [Key(0)]
    public long UserId { get; set; }

    [Key(1)]
    public int PremiumItemId { get; set; }

    [Key(2)]
    public long AcquisitionDatetime { get; set; }

    [Key(3)]
    public long LatestVersion { get; set; }
}
