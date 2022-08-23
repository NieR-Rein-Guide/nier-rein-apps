using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_shop_item")]
    public class EntityMShopItem
    {
        [Key(0)] // RVA: 0x1DDFA14 Offset: 0x1DDFA14 VA: 0x1DDFA14
        public int ShopItemId { get; set; } // 0x10
        [Key(1)] // RVA: 0x1DDFA54 Offset: 0x1DDFA54 VA: 0x1DDFA54
        public int NameShopTextId { get; set; } // 0x14
        [Key(2)] // RVA: 0x1DDFA68 Offset: 0x1DDFA68 VA: 0x1DDFA68
        public int DescriptionShopTextId { get; set; } // 0x18
        [Key(3)] // RVA: 0x1DDFA7C Offset: 0x1DDFA7C VA: 0x1DDFA7C
        public int ShopItemContentType { get; set; } // 0x1C
        [Key(4)] // RVA: 0x1DDFA90 Offset: 0x1DDFA90 VA: 0x1DDFA90
        public PriceType PriceType { get; set; }  // 0x20
        [Key(5)] // RVA: 0x1DDFAA4 Offset: 0x1DDFAA4 VA: 0x1DDFAA4
        public int PriceId { get; set; } // 0x24
        [Key(6)] // RVA: 0x1DDFAB8 Offset: 0x1DDFAB8 VA: 0x1DDFAB8
        public int Price { get; set; } // 0x28
        [Key(7)] // RVA: 0x1DDFACC Offset: 0x1DDFACC VA: 0x1DDFACC
        public int RegularPrice { get; set; } // 0x2C
        [Key(8)] // RVA: 0x1DDFAE0 Offset: 0x1DDFAE0 VA: 0x1DDFAE0
        public ShopPromotionType ShopPromotionType { get; set; } // 0x30
        [Key(9)] // RVA: 0x1DDFAF4 Offset: 0x1DDFAF4 VA: 0x1DDFAF4
        public int ShopItemLimitedStockId { get; set; } // 0x34
        [Key(10)] // RVA: 0x1DDFB08 Offset: 0x1DDFB08 VA: 0x1DDFB08
        public int AssetCategoryId { get; set; } // 0x38
        [Key(11)] // RVA: 0x1DDFB1C Offset: 0x1DDFB1C VA: 0x1DDFB1C
        public int AssetVariationId { get; set; } // 0x3C
        [Key(12)] // RVA: 0x1DDFB30 Offset: 0x1DDFB30 VA: 0x1DDFB30
        public ShopItemDecorationType ShopItemDecorationType { get; set; } // 0x40
	}
}
