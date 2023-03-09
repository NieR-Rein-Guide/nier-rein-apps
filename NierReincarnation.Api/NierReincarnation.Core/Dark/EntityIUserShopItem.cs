using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_shop_item")]
    public class EntityIUserShopItem
    {
        [Key(0)] // RVA: 0x1DE7838 Offset: 0x1DE7838 VA: 0x1DE7838
        public long UserId { get; set; }
        [Key(1)] // RVA: 0x1DE7878 Offset: 0x1DE7878 VA: 0x1DE7878
        public int ShopItemId { get; set; }
        [Key(2)] // RVA: 0x1DE78B8 Offset: 0x1DE78B8 VA: 0x1DE78B8
        public int BoughtCount { get; set; }
        [Key(3)] // RVA: 0x1DE78CC Offset: 0x1DE78CC VA: 0x1DE78CC
        public long LatestBoughtCountChangedDatetime { get; set; }
        [Key(4)] // RVA: 0x1DE78E0 Offset: 0x1DE78E0 VA: 0x1DE78E0
        public long LatestVersion { get; set; }
	}
}
