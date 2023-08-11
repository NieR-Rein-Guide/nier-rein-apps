using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_shop_item_user_level_condition")]
    public class EntityMShopItemUserLevelCondition
    {
        [Key(0)]
        public int ShopItemId { get; set; }

        [Key(1)]
        public int UserLevelUpperLimit { get; set; }

        [Key(2)]
        public int UserLevelLowerLimit { get; set; }

        [Key(3)]
        public int ShopItemAdditionalContentId { get; set; }
    }
}
