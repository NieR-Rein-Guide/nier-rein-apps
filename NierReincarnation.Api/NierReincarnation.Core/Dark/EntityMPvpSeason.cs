using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_pvp_season")]
    public class EntityMPvpSeason
    {
        [Key(0)]
        public int PvpSeasonId { get; set; } // 0x10
        [Key(1)]
        public string NameAssetPath { get; set; } // 0x18
        [Key(2)]
        public long SeasonStartDatetime { get; set; } // 0x20
        [Key(3)]
        public long SeasonEndDatetime { get; set; } // 0x28
        [Key(4)]
        public int PvpSeasonGroupingId { get; set; } // 0x30
        [Key(5)]
        public bool IsInvalid { get; set; } // 0x34
        [Key(6)]
        public int PvpWeeklyRankRewardRankGroupId { get; set; } // 0x38
        [Key(7)]
        public int PvpSeasonRankRewardRankGroupId { get; set; } // 0x3C
        [Key(8)]
        public int PvpGradeGroupId { get; set; } // 0x40
        [Key(9)]
        public int PvpInitialPointAdditionGroupId { get; set; } // 0x44
        [Key(10)]
        public int PvpSeasonDeckPowerThresholdGroupingId { get; set; } // 0x48
    }
}