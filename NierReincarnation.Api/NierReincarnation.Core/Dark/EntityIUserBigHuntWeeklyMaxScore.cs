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
        public long UserId { get; set; }

        [Key(1)]
        public long BigHuntWeeklyVersion { get; set; }

        [Key(2)]
        public AttributeType AttributeType { get; set; }

        [Key(3)]
        public long MaxScore { get; set; }

        [Key(4)]
        public long LatestVersion { get; set; }
    }
}
