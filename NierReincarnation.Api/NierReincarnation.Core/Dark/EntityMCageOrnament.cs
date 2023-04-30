using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_cage_ornament")]
    public class EntityMCageOrnament
    {
        [Key(0)]
        public int CageOrnamentId { get; set; } // 0x10

        [Key(1)]
        public long StartDatetime { get; set; } // 0x18

        [Key(2)]
        public long EndDatetime { get; set; } // 0x20

        [Key(3)]
        public int CageOrnamentRewardId { get; set; } // 0x28
    }
}
