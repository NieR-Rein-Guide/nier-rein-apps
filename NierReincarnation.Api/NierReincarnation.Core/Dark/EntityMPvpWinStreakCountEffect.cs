using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_pvp_win_streak_count_effect")]
    public class EntityMPvpWinStreakCountEffect
    {
        [Key(0)]
        public int WinStreakCount { get; set; } // 0x10

        [Key(1)]
        public int AbilityId { get; set; } // 0x14

        [Key(2)]
        public int AbilityLevel { get; set; } // 0x18
    }
}
