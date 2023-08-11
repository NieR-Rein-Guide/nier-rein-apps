using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_evaluate_condition")]
    public class EntityMEvaluateCondition
    {
        [Key(0)]
        public int EvaluateConditionId { get; set; }

        [Key(1)]
        public EvaluateConditionFunctionType EvaluateConditionFunctionType { get; set; }

        [Key(2)]
        public EvaluateConditionEvaluateType EvaluateConditionEvaluateType { get; set; }

        [Key(3)]
        public int EvaluateConditionValueGroupId { get; set; }

        [Key(4)]
        public int NameEvaluateConditionTextId { get; set; }
    }
}
