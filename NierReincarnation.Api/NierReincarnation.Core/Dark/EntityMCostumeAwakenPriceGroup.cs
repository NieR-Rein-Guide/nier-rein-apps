using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_costume_awaken_price_group")]
    public class EntityMCostumeAwakenPriceGroup
    {
        [Key(0)]
        public int CostumeAwakenPriceGroupId { get; set; } // 0x10

        [Key(1)]
        public int AwakenStepLowerLimit { get; set; } // 0x14

        [Key(2)]
        public int Gold { get; set; } // 0x18
    }
}
