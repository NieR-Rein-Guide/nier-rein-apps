using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_mom_banner")]
    public class EntityMMomBanner
    {
        [Key(0)]
        public int MomBannerId { get; set; } // 0x10
        [Key(1)]
        public int SortOrderDesc { get; set; } // 0x14
        [Key(2)]
        public DomainType DestinationDomainType { get; set; } // 0x18
        [Key(3)]
        public int DestinationDomainId { get; set; } // 0x1C
        [Key(4)]
        public string BannerAssetName { get; set; } // 0x20
        [Key(5)]
        public bool IsEmphasis { get; set; } // 0x28
        [Key(6)]
        public long StartDatetime { get; set; } // 0x30
        [Key(7)]
        public long EndDatetime { get; set; } // 0x38
        [Key(8)]
        public TargetUserStatusType TargetUserStatusType { get; set; } // 0x40
    }
}