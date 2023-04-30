using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_big_hunt_weekly_status")]
    public class EntityIUserBigHuntWeeklyStatus
    {
        [Key(0)]
        public long UserId { get; set; } // 0x10

        [Key(1)]
        public long BigHuntWeeklyVersion { get; set; } // 0x18

        [Key(2)]
        public bool IsReceivedWeeklyReward { get; set; } // 0x20

        [Key(3)]
        public long LatestVersion { get; set; } // 0x28
    }
}
