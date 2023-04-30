using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_omikuji")]
    public class EntityMOmikuji
    {
        [Key(0)]
        public int OmikujiId { get; set; } // 0x10

        [Key(1)]
        public long StartDatetime { get; set; } // 0x18

        [Key(2)]
        public long EndDatetime { get; set; } // 0x20

        [Key(3)]
        public int OmikujiAssetId { get; set; } // 0x28
    }
}
