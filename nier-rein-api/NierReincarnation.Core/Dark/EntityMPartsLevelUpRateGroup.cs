using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_parts_level_up_rate_group")]
    public class EntityMPartsLevelUpRateGroup
    {
        [Key(0)]
        public int PartsLevelUpRateGroupId { get; set; } // 0x10
        [Key(1)]
        public int LevelLowerLimit { get; set; } // 0x14
        [Key(2)]
        public int SuccessRatePermil { get; set; } // 0x18
    }
}