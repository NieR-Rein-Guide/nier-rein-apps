using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_pvp_season_grouping")]
    public class EntityMPvpSeasonGrouping
    {
        [Key(0)]
        public int PvpSeasonGroupingId { get; set; } // 0x10

        [Key(1)]
        public int GroupId { get; set; } // 0x14

        [Key(2)]
        public int DivideWeight { get; set; } // 0x18
    }
}
