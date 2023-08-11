using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_portal_cage_status")]
    public class EntityIUserPortalCageStatus
    {
        [Key(0)]
        public long UserId { get; set; }

        [Key(1)]
        public bool IsCurrentProgress { get; set; }

        [Key(2)]
        public long DropItemStartDatetime { get; set; }

        [Key(3)]
        public int CurrentDropItemCount { get; set; }

        [Key(4)]
        public long LatestVersion { get; set; }
    }
}
