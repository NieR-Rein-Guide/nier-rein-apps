using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_evaluate_condition_value_group")]
    public class EntityMEvaluateConditionValueGroup
    {
        [Key(0)]
        public int EvaluateConditionValueGroupId { get; set; } // 0x10

        [Key(1)]
        public int GroupIndex { get; set; } // 0x14

        [Key(2)]
        public long Value { get; set; } // 0x18
    }
}
