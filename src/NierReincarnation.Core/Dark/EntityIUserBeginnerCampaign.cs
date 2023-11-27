using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityIUserBeginnerCampaign))]
public class EntityIUserBeginnerCampaign
{
    [Key(0)]
    public long UserId { get; set; }

    [Key(1)]
    public int BeginnerCampaignId { get; set; }

    [Key(2)]
    public long CampaignRegisterDatetime { get; set; }

    [Key(3)]
    public long LatestVersion { get; set; }
}
