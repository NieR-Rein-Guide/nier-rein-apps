using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_shop_replaceable_lineup")]
    public class EntityIUserShopReplaceableLineup
    {
        [Key(0)]
        public long UserId { get; set; } // 0x10
        [Key(1)]
        public int SlotNumber { get; set; } // 0x18
        [Key(2)]
        public int ShopItemId { get; set; } // 0x1C
        [Key(3)]
        public long LatestVersion { get; set; } // 0x20
    }
}