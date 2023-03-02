using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_movie")]
    public class EntityMMovie
    {
        [Key(0)]
        public int MovieId { get; set; } // 0x10
        [Key(1)]
        public int AssetId { get; set; } // 0x14
    }
}