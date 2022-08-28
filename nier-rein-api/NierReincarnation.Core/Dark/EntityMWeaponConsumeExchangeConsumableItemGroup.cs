using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_weapon_consume_exchange_consumable_item_group")]
    public class EntityMWeaponConsumeExchangeConsumableItemGroup
    {
        [Key(0)]
        public int WeaponId { get; set; } // 0x10
        [Key(1)]
        public int ConsumableItemId { get; set; } // 0x14
        [Key(2)]
        public int Count { get; set; } // 0x18
    }
}