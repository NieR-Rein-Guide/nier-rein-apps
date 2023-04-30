using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_gimmick_sequence")]
    public class EntityIUserGimmickSequence
    {
        [Key(0)]
        public long UserId { get; set; } // 0x10

        [Key(1)]
        public int GimmickSequenceScheduleId { get; set; } // 0x18

        [Key(2)]
        public int GimmickSequenceId { get; set; } // 0x1C

        [Key(3)]
        public bool IsGimmickSequenceCleared { get; set; } // 0x20

        [Key(4)]
        public long ClearDatetime { get; set; } // 0x28

        [Key(5)]
        public long LatestVersion { get; set; } // 0x30
    }
}
