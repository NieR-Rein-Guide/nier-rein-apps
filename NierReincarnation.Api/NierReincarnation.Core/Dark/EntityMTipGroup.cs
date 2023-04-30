using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_tip_group")]
    public class EntityMTipGroup
    {
        [Key(0)]
        public int TipGroupId { get; set; } // 0x10

        [Key(1)]
        public int NameTextId { get; set; } // 0x14
    }
}
