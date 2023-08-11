using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_omikuji")]
    public class EntityMOmikuji
    {
        [Key(0)]
        public int OmikujiId { get; set; }

        [Key(1)]
        public long StartDatetime { get; set; }

        [Key(2)]
        public long EndDatetime { get; set; }

        [Key(3)]
        public int OmikujiAssetId { get; set; }
    }
}
