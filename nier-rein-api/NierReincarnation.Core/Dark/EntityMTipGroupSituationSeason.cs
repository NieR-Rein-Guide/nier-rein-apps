using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_tip_group_situation_season")]
    public class EntityMTipGroupSituationSeason
    {
        [Key(0)]
        public int TipSituationType { get; set; } // 0x10
        [Key(1)]
        public int TipSituationSeasonId { get; set; } // 0x14
        [Key(2)]
        public int TipGroupId { get; set; } // 0x18
        [Key(3)]
        public int Weight { get; set; } // 0x1C
        [Key(4)]
        public int TargetId { get; set; } // 0x20
    }
}