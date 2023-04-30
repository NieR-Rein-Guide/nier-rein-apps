using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_gimmick")]
    public class EntityIUserGimmick
    {
        [Key(0)]
        public long UserId { get; set; } // 0x10

        [Key(1)]
        public int GimmickSequenceScheduleId { get; set; } // 0x18

        [Key(2)]
        public int GimmickSequenceId { get; set; } // 0x1C

        [Key(3)]
        public int GimmickId { get; set; } // 0x20

        [Key(4)]
        public bool IsGimmickCleared { get; set; } // 0x24

        [Key(5)]
        public long StartDatetime { get; set; } // 0x28

        [Key(6)]
        public long LatestVersion { get; set; } // 0x30
    }
}
