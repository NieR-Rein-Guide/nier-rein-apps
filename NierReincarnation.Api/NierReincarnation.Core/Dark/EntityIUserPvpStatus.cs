using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_pvp_status")]
    public class EntityIUserPvpStatus
    {
        [Key(0)]
        public long UserId { get; set; } // 0x10
        [Key(1)]
        public int StaminaMilliValue { get; set; } // 0x18
        [Key(2)]
        public long StaminaUpdateDatetime { get; set; } // 0x20
        [Key(3)]
        public int LatestRewardReceivePvpSeasonId { get; set; } // 0x28
        [Key(4)]
        public long LatestRewardReceivePvpWeeklyVersion { get; set; } // 0x30
        [Key(5)]
        public int WinStreakCount { get; set; } // 0x38
        [Key(6)]
        public long WinStreakCountUpdateDatetime { get; set; } // 0x40
        [Key(7)]
        public long LatestVersion { get; set; } // 0x48
    }
}