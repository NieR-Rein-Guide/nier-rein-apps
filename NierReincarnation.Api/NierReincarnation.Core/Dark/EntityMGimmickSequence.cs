using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_gimmick_sequence")]
    public class EntityMGimmickSequence
    {
        [Key(0)]
        public int GimmickSequenceId { get; set; } // 0x10

        [Key(1)]
        public int GimmickSequenceClearConditionType { get; set; } // 0x14

        [Key(2)]
        public int NextGimmickSequenceGroupId { get; set; } // 0x18

        [Key(3)]
        public int GimmickGroupId { get; set; } // 0x1C

        [Key(4)]
        public int GimmickSequenceRewardGroupId { get; set; } // 0x20

        [Key(5)]
        public FlowType FlowType { get; set; } // 0x24

        [Key(6)]
        public int ProgressRequireHour { get; set; } // 0x28

        [Key(7)]
        public long ProgressStartDatetime { get; set; } // 0x30
    }
}
