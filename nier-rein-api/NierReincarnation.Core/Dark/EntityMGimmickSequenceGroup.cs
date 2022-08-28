using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_gimmick_sequence_group")]
    public class EntityMGimmickSequenceGroup
    {
        [Key(0)]
        public int GimmickSequenceGroupId { get; set; } // 0x10
        [Key(1)]
        public int GroupIndex { get; set; } // 0x14
        [Key(2)]
        public int GimmickSequenceId { get; set; } // 0x18
    }
}