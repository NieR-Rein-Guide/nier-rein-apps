using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_consumable_item_effect")]
    public class EntityMConsumableItemEffect
    {
        [Key(0)] // RVA: 0x1DD869C Offset: 0x1DD869C VA: 0x1DD869C
        public int ConsumableItemId { get; set; } // 0x10

        [Key(1)] // RVA: 0x1DD86DC Offset: 0x1DD86DC VA: 0x1DD86DC
        public EffectTargetType EffectTargetType { get; set; } // 0x14

        [Key(2)] // RVA: 0x1DD86F0 Offset: 0x1DD86F0 VA: 0x1DD86F0
        public EffectValueType EffectValueType { get; set; } // 0x18

        [Key(3)] // RVA: 0x1DD8704 Offset: 0x1DD8704 VA: 0x1DD8704
        public int EffectValue { get; set; } // 0x1C
    }
}
