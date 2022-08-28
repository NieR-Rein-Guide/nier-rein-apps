using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_shop_replaceable_gem")]
    public class EntityMShopReplaceableGem
    {
        [Key(0)]
        public int LineupUpdateCountLowerLimit { get; set; } // 0x10
        [Key(1)]
        public int NecessaryGem { get; set; } // 0x14
    }
}