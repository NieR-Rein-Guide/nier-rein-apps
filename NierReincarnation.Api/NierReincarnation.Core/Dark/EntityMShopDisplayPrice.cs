using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_shop_display_price")]
    public class EntityMShopDisplayPrice
    {
        [Key(0)]
        public PriceType PriceType { get; set; } // 0x10

        [Key(1)]
        public int PriceId { get; set; } // 0x14

        [Key(2)]
        public int SortOrder { get; set; } // 0x18
    }
}
