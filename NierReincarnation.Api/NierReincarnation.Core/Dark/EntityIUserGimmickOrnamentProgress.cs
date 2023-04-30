using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_gimmick_ornament_progress")]
    public class EntityIUserGimmickOrnamentProgress
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
        public int GimmickOrnamentIndex { get; set; } // 0x24

        [Key(5)]
        public int ProgressValueBit { get; set; } // 0x28

        [Key(6)]
        public long BaseDatetime { get; set; } // 0x30

        [Key(7)]
        public long LatestVersion { get; set; } // 0x38
    }
}
