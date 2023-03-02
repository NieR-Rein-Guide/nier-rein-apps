using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_shop_item_content_mission")]
    public class EntityMShopItemContentMission
    {
        [Key(0)]
        public int ShopItemId { get; set; } // 0x10
        [Key(1)]
        public int MissionGroupId { get; set; } // 0x14
        [Key(2)]
        public bool IsReevaluateOnGrant { get; set; } // 0x18
    }
}