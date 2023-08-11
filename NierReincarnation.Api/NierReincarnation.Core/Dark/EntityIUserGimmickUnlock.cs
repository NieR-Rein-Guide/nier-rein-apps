using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_gimmick_unlock")]
    public class EntityIUserGimmickUnlock
    {
        [Key(0)]
        public long UserId { get; set; }

        [Key(1)]
        public int GimmickSequenceScheduleId { get; set; }

        [Key(2)]
        public int GimmickSequenceId { get; set; }

        [Key(3)]
        public int GimmickId { get; set; }

        [Key(4)]
        public bool IsUnlocked { get; set; }

        [Key(5)]
        public long LatestVersion { get; set; }
    }
}
