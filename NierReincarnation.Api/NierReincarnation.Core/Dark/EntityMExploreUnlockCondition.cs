using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_explore_unlock_condition")]
    public class EntityMExploreUnlockCondition
    {
        [Key(0)]
        public int ExploreUnlockConditionId { get; set; } // 0x10

        [Key(1)]
        public ExploreUnlockConditionType ExploreUnlockConditionType { get; set; } // 0x14

        [Key(2)]
        public int ConditionValue { get; set; } // 0x18
    }
}
