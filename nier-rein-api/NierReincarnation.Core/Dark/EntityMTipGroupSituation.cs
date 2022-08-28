using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_tip_group_situation")]
    public class EntityMTipGroupSituation
    {
        [Key(0)]
        public int TipSituationType { get; set; } // 0x10
        [Key(1)]
        public int TipGroupId { get; set; } // 0x14
        [Key(2)]
        public int Weight { get; set; } // 0x18
        [Key(3)]
        public int TargetId { get; set; } // 0x1C
    }
}