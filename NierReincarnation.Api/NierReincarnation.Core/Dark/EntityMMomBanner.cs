using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_mom_banner")]
public class EntityMMomBanner
{
    [Key(0)]
    public int MomBannerId { get; set; }

    [Key(1)]
    public int SortOrderDesc { get; set; }

    [Key(2)]
    public DomainType DestinationDomainType { get; set; }

    [Key(3)]
    public int DestinationDomainId { get; set; }

    [Key(4)]
    public string BannerAssetName { get; set; }

    [Key(5)]
    public bool IsEmphasis { get; set; }

    [Key(6)]
    public long StartDatetime { get; set; }

    [Key(7)]
    public long EndDatetime { get; set; }

    [Key(8)]
    public TargetUserStatusType TargetUserStatusType { get; set; }
}
