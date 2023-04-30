using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_gimmick_sequence_schedule")]
    public class EntityMGimmickSequenceSchedule
    {
        [Key(0)]
        public int GimmickSequenceScheduleId { get; set; } // 0x10

        [Key(1)]
        public long StartDatetime { get; set; } // 0x18

        [Key(2)]
        public long EndDatetime { get; set; } // 0x20

        [Key(3)]
        public int FirstGimmickSequenceId { get; set; } // 0x28

        [Key(4)]
        public int ReleaseEvaluateConditionId { get; set; } // 0x2C
    }
}
