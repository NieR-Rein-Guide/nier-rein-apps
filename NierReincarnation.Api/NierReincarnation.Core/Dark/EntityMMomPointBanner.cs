using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_mom_point_banner")]
    public class EntityMMomPointBanner
    {
        [Key(0)]
        public int MomPointBannerId { get; set; } // 0x10

        [Key(1)]
        public int BannerAssetId { get; set; } // 0x14

        [Key(2)]
        public int DestinationInformationId { get; set; } // 0x18

        [Key(3)]
        public long StartDatetime { get; set; } // 0x20

        [Key(4)]
        public long EndDatetime { get; set; } // 0x28
    }
}
