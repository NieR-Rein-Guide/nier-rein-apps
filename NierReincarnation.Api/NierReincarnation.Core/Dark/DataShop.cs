namespace NierReincarnation.Core.Dark;

public class DataShop
{
    public int ShopId { get; set; }

    public string Name { get; set; }

    public ShopUpdatableLabelType ShopUpdatableLabelType { get; set; }

    public long StartDateTime { get; set; }

    public long EndDateTime { get; set; }

    public bool IsLimitedOpen { get; set; }

    public ShopType ShopType { get; set; }

    public ShopExchangeType ShopExchangeType { get; set; }
}
