using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_shop_item_user_level_condition")]
    public class EntityMShopItemUserLevelCondition
    {
        [Key(0)]
        public int ShopItemId { get; set; } // 0x10

        [Key(1)]
        public int UserLevelUpperLimit { get; set; } // 0x14

        [Key(2)]
        public int UserLevelLowerLimit { get; set; } // 0x18

        [Key(3)]
        public int ShopItemAdditionalContentId { get; set; } // 0x1C
    }
}
