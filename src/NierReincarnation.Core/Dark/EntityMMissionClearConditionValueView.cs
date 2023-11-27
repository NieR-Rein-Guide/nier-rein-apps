using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMMissionClearConditionValueView))]
public class EntityMMissionClearConditionValueView
{
    [Key(0)]
    public MissionClearConditionType MissionClearConditionType { get; set; }

    [Key(1)]
    public int ViewClearConditionValue { get; set; }
}
