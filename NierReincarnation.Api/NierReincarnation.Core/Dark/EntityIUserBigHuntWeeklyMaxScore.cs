using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_big_hunt_weekly_max_score")]
    public class EntityIUserBigHuntWeeklyMaxScore
    {
        [Key(0)]
        public long UserId { get; set; } // 0x10

        [Key(1)]
        public long BigHuntWeeklyVersion { get; set; } // 0x18

        [Key(2)]
        public AttributeType AttributeType { get; set; } // 0x20

        [Key(3)]
        public long MaxScore { get; set; } // 0x28

        [Key(4)]
        public long LatestVersion { get; set; } // 0x30
    }
}
