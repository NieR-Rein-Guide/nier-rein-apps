using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_gimmick_interval")]
    public class EntityMGimmickInterval
    {
        [Key(0)]
        public int GimmickId { get; set; } // 0x10
        [Key(1)]
        public int InitialValue { get; set; } // 0x14
        [Key(2)]
        public int MaxValue { get; set; } // 0x18
        [Key(3)]
        public int IntervalValue { get; set; } // 0x1C
    }
}