using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_tip_group_selection")]
    public class EntityMTipGroupSelection
    {
        [Key(0)]
        public int TipGroupId { get; set; } // 0x10

        [Key(1)]
        public int TipId { get; set; } // 0x14

        [Key(2)]
        public int EncounterRatePermil { get; set; } // 0x18
    }
}
