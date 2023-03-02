namespace NierReincarnation.Core.Dark
{
    public class DataConsumableItem
    {
        // 0x10
        public int ConsumableItemId { get; set; }
        // 0x18
        public string Name { get; set; }
        // 0x20
        public string Description { get; set; }
        // 0x28
        public int AssetCategoryId { get; set; }
        // 0x2C
        public int AssetVariationId { get; set; }
        // 0x30
        public int HoldNum { get; set; }
        // 0x34
        public int ConsumableItemTermId { get; set; }
	}
}
