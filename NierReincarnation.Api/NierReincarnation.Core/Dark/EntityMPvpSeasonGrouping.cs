using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_pvp_season_grouping")]
    public class EntityMPvpSeasonGrouping
    {
        [Key(0)]
        public int PvpSeasonGroupingId { get; set; }

        [Key(1)]
        public int GroupId { get; set; }

        [Key(2)]
        public int DivideWeight { get; set; }
    }
}
