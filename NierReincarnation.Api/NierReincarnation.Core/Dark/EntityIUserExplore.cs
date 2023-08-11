using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_explore")]
    public class EntityIUserExplore
    {
        [Key(0)]
        public long UserId { get; set; }

        [Key(1)]
        public bool IsUseExploreTicket { get; set; }

        [Key(2)]
        public int PlayingExploreId { get; set; }

        [Key(3)]
        public long LatestPlayDatetime { get; set; }

        [Key(4)]
        public long LatestVersion { get; set; }
    }
}
