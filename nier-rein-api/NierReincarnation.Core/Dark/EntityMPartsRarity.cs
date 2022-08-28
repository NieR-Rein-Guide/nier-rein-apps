using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_parts_rarity")]
    public class EntityMPartsRarity
    {
        [Key(0)]
        public int RarityType { get; set; } // 0x10
        [Key(1)]
        public int PartsLevelUpRateGroupId { get; set; } // 0x14
        [Key(2)]
        public int PartsLevelUpPriceGroupId { get; set; } // 0x18
        [Key(3)]
        public int SellPriceNumericalFunctionId { get; set; } // 0x1C
    }
}