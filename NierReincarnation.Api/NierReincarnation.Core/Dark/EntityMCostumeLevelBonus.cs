using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_costume_level_bonus")]
    public class EntityMCostumeLevelBonus
    {
        [Key(0)]
        public int CostumeLevelBonusId { get; set; }

        [Key(1)]
        public int Level { get; set; }

        [Key(2)]
        public CostumeLevelBonusType CostumeLevelBonusType { get; set; }

        [Key(3)]
        public int EffectValue { get; set; }
    }
}
