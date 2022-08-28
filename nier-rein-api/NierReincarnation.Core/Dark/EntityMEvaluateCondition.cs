using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_evaluate_condition")]
    public class EntityMEvaluateCondition
    {
        [Key(0)]
        public int EvaluateConditionId { get; set; } // 0x10
        [Key(1)]
        public int EvaluateConditionFunctionType { get; set; } // 0x14
        [Key(2)]
        public int EvaluateConditionEvaluateType { get; set; } // 0x18
        [Key(3)]
        public int EvaluateConditionValueGroupId { get; set; } // 0x1C
        [Key(4)]
        public int NameEvaluateConditionTextId { get; set; } // 0x20
    }
}