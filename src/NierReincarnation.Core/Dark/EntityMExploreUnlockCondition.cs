using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMExploreUnlockCondition))]
public class EntityMExploreUnlockCondition
{
    [Key(0)]
    public int ExploreUnlockConditionId { get; set; }

    [Key(1)]
    public ExploreUnlockConditionType ExploreUnlockConditionType { get; set; }

    [Key(2)]
    public int ConditionValue { get; set; }
}
