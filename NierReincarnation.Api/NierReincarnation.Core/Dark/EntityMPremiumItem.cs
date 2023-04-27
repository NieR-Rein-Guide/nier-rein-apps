using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_premium_item")]
    public class EntityMPremiumItem
    {
        [Key(0)]
        public int PremiumItemId { get; set; } // 0x10

        [Key(1)]
        public int PremiumItemType { get; set; } // 0x14

        [Key(2)]
        public long StartDatetime { get; set; } // 0x18

        [Key(3)]
        public long EndDatetime { get; set; } // 0x20
    }
}
