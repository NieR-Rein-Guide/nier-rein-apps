using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_weapon_consume_exchange_consumable_item_group")]
public class EntityMWeaponConsumeExchangeConsumableItemGroup
{
    [Key(0)]
    public int WeaponId { get; set; }

    [Key(1)]
    public int ConsumableItemId { get; set; }

    [Key(2)]
    public int Count { get; set; }
}
