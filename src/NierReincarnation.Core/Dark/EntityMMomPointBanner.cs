using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMMomPointBanner))]
public class EntityMMomPointBanner
{
    [Key(0)]
    public int MomPointBannerId { get; set; }

    [Key(1)]
    public int BannerAssetId { get; set; }

    [Key(2)]
    public int DestinationInformationId { get; set; }

    [Key(3)]
    public long StartDatetime { get; set; }

    [Key(4)]
    public long EndDatetime { get; set; }
}
