using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_shop")]
    public class EntityMShop
    {
        [Key(0)] // RVA: 0x1DDF864 Offset: 0x1DDF864 VA: 0x1DDF864
        public int ShopId { get; set; } // 0x10

        [Key(1)] // RVA: 0x1DDF8A4 Offset: 0x1DDF8A4 VA: 0x1DDF8A4
        public ShopGroupType ShopGroupType { get; set; } // 0x14

        [Key(2)] // RVA: 0x1DDF8B8 Offset: 0x1DDF8B8 VA: 0x1DDF8B8
        public int SortOrderInShopGroup { get; set; } // 0x18

        [Key(3)] // RVA: 0x1DDF8CC Offset: 0x1DDF8CC VA: 0x1DDF8CC
        public ShopType ShopType { get; set; } // 0x1C

        [Key(4)] // RVA: 0x1DDF8E0 Offset: 0x1DDF8E0 VA: 0x1DDF8E0
        public int NameShopTextId { get; set; } // 0x20

        [Key(5)] // RVA: 0x1DDF8F4 Offset: 0x1DDF8F4 VA: 0x1DDF8F4
        public ShopUpdatableLabelType ShopUpdatableLabelType { get; set; } // 0x24

        [Key(6)] // RVA: 0x1DDF908 Offset: 0x1DDF908 VA: 0x1DDF908
        public ShopExchangeType ShopExchangeType { get; set; } // 0x28

        [Key(7)] // RVA: 0x1DDF91C Offset: 0x1DDF91C VA: 0x1DDF91C
        public int ShopItemCellGroupId { get; set; } // 0x2C

        [Key(8)] // RVA: 0x1DDF930 Offset: 0x1DDF930 VA: 0x1DDF930
        public MainFunctionType RelatedMainFunctionType { get; set; } // 0x30

        [Key(9)] // RVA: 0x1DDF944 Offset: 0x1DDF944 VA: 0x1DDF944
        public long StartDatetime { get; set; } // 0x38

        [Key(10)] // RVA: 0x1DDF958 Offset: 0x1DDF958 VA: 0x1DDF958
        public long EndDatetime { get; set; } // 0x40

        [Key(11)] // RVA: 0x1DDF96C Offset: 0x1DDF96C VA: 0x1DDF96C
        public int LimitedOpenId { get; set; } // 0x48
    }
}
