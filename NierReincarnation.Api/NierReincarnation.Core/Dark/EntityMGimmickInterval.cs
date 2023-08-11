using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_gimmick_interval")]
    public class EntityMGimmickInterval
    {
        [Key(0)]
        public int GimmickId { get; set; }

        [Key(1)]
        public int InitialValue { get; set; }

        [Key(2)]
        public int MaxValue { get; set; }

        [Key(3)]
        public int IntervalValue { get; set; }
    }
}
