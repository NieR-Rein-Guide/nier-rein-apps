using System.Collections.Generic;
using NierReincarnation.Core.Dark.Generated.Type;

namespace NierReincarnation.Core.Dark
{
    public class DataShopItem
    {
        public int ShopItemId { get; set; } // 0x10
        public int SortOrder { get; set; }
        public string ItemName { get; set; }
        public string DescriptionText { get; set; } // 0x20
        public DataPriceType DataPriceType { get; set; }
        public int Price { get; set; }  // 0x30
        public int OldPrice { get; set; } // 0x34
        public decimal PlatformPrice { get; set; } // 0x38
        public string PlatformPriceString { get; set; } // 0x48
        public string ProductId { get; set; } // 0x50
        public ShopPromotionType ShopPromotionType { get; set; } // 0x58
        public ShopItemDecorationType ShopItemDecorationType { get; set; } // 0x5C
        public int AssetCategoryId { get; set; } // 0x60
        public int AssetVariationId { get; set; } // 0x64
        public long StartUnixTime { get; set; } // 0x68
        public long EndUnixTime { get; set; } // 0x70
        public List<DataPossessionItem> DataPossessionItemList { get; set; } // 0x78
        public DataContentEffect DataContentEffect { get; set; } // 0x80
        public bool IsLimitedStock { get; set; } // 0x88
        public int RemainingStock { get; set; } // 0x8C
	}
}
