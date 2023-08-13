namespace NierReincarnation.Core.Dark;

public class DataShopItem
{
    public int ShopItemId { get; set; }

    public int SortOrder { get; set; }

    public string ItemName { get; set; }

    public string DescriptionText { get; set; }

    public DataPriceType DataPriceType { get; set; }

    public int Price { get; set; }

    public int OldPrice { get; set; }

    public decimal PlatformPrice { get; set; }

    public string PlatformPriceString { get; set; }

    public string ProductId { get; set; }

    public ShopPromotionType ShopPromotionType { get; set; }

    public ShopItemDecorationType ShopItemDecorationType { get; set; }

    public int AssetCategoryId { get; set; }

    public int AssetVariationId { get; set; }

    public long StartUnixTime { get; set; }

    public long EndUnixTime { get; set; }

    public List<DataPossessionItem> DataPossessionItemList { get; set; }

    public DataContentEffect DataContentEffect { get; set; }

    public bool IsLimitedStock { get; set; }

    public int RemainingStock { get; set; }
}
