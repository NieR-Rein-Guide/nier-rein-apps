using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_shop_item_content_mission")]
public class EntityMShopItemContentMission
{
    [Key(0)]
    public int ShopItemId { get; set; }

    [Key(1)]
    public int MissionGroupId { get; set; }

    [Key(2)]
    public bool IsReevaluateOnGrant { get; set; }
}
