using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_shop_item")]
    public class EntityIUserShopItem
    {
        [Key(0)]
        public long UserId { get; set; }

        [Key(1)]
        public int ShopItemId { get; set; }

        [Key(2)]
        public int BoughtCount { get; set; }

        [Key(3)]
        public long LatestBoughtCountChangedDatetime { get; set; }

        [Key(4)]
        public long LatestVersion { get; set; }
    }
}
