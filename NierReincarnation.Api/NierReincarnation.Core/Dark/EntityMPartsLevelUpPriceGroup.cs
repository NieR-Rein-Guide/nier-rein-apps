using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_parts_level_up_price_group")]
    public class EntityMPartsLevelUpPriceGroup
    {
        [Key(0)]
        public int PartsLevelUpPriceGroupId { get; set; } // 0x10

        [Key(1)]
        public int LevelLowerLimit { get; set; } // 0x14

        [Key(2)]
        public int Gold { get; set; } // 0x18
    }
}
