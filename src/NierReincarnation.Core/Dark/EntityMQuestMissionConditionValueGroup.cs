using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMQuestMissionConditionValueGroup))]
public class EntityMQuestMissionConditionValueGroup
{
    [Key(0)]
    public int QuestMissionConditionValueGroupId { get; set; }

    [Key(1)]
    public int SortOrder { get; set; }

    [Key(2)]
    public int ConditionValue { get; set; }
}
