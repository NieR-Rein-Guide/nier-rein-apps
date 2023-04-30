using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_gacha_medal")]
    public class EntityMGachaMedal
    {
        [Key(0)]
        public int GachaMedalId { get; set; } // 0x10

        [Key(1)]
        public int CeilingCount { get; set; } // 0x14

        [Key(2)]
        public int ConsumableItemId { get; set; } // 0x18

        [Key(3)]
        public int ShopTransitionGachaId { get; set; } // 0x1C

        [Key(4)]
        public long AutoConvertDatetime { get; set; } // 0x20

        [Key(5)]
        public int ConversionRate { get; set; } // 0x28
    }
}
