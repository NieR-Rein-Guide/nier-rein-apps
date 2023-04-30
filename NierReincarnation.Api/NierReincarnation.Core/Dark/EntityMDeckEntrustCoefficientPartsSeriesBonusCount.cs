using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_deck_entrust_coefficient_parts_series_bonus_count")]
    public class EntityMDeckEntrustCoefficientPartsSeriesBonusCount
    {
        [Key(0)]
        public int PartsSeriesBonusCount { get; set; } // 0x10

        [Key(1)]
        public int CoefficientPermil { get; set; } // 0x14
    }
}
