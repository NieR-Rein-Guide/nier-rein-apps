using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_consumable_item_term")]
    public class EntityMConsumableItemTerm
    {
        [Key(0)] // RVA: 0x1DD8718 Offset: 0x1DD8718 VA: 0x1DD8718
        public int ConsumableItemTermId { get; set; }

        [Key(1)] // RVA: 0x1DD8758 Offset: 0x1DD8758 VA: 0x1DD8758
        public long StartDatetime { get; set; }

        [Key(2)] // RVA: 0x1DD876C Offset: 0x1DD876C VA: 0x1DD876C
        public long EndDatetime { get; set; }
    }
}
