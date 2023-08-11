using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_pvp_status")]
    public class EntityIUserPvpStatus
    {
        [Key(0)]
        public long UserId { get; set; }

        [Key(1)]
        public int StaminaMilliValue { get; set; }

        [Key(2)]
        public long StaminaUpdateDatetime { get; set; }

        [Key(3)]
        public int LatestRewardReceivePvpSeasonId { get; set; }

        [Key(4)]
        public long LatestRewardReceivePvpWeeklyVersion { get; set; }

        [Key(5)]
        public int WinStreakCount { get; set; }

        [Key(6)]
        public long WinStreakCountUpdateDatetime { get; set; }

        [Key(7)]
        public long LatestVersion { get; set; }
    }
}
