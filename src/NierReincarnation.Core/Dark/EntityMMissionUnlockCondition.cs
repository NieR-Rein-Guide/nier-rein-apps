using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMMissionUnlockCondition))]
public class EntityMMissionUnlockCondition
{
    [Key(0)]
    public int MissionUnlockConditionId { get; set; }

    [Key(1)]
    public MissionUnlockConditionType MissionUnlockConditionType { get; set; }

    [Key(2)]
    public int ConditionValue { get; set; }
}
