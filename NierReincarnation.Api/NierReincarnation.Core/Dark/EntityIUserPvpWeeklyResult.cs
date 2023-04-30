using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_pvp_weekly_result")]
    public class EntityIUserPvpWeeklyResult
    {
        [Key(0)]
        public long UserId { get; set; } // 0x10

        [Key(1)]
        public long PvpWeeklyVersion { get; set; } // 0x18

        [Key(2)]
        public int PvpSeasonId { get; set; } // 0x20

        [Key(3)]
        public int GroupId { get; set; } // 0x24

        [Key(4)]
        public int FinalPoint { get; set; } // 0x28

        [Key(5)]
        public int FinalRank { get; set; } // 0x2C

        [Key(6)]
        public long LatestVersion { get; set; } // 0x30
    }
}
