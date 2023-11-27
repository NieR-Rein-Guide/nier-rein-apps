using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMQuestReleaseConditionList))]
public class EntityMQuestReleaseConditionList
{
    [Key(0)]
    public int QuestReleaseConditionListId { get; set; }

    [Key(1)]
    public int QuestReleaseConditionGroupId { get; set; }

    [Key(2)]
    public ConditionOperationType ConditionOperationType { get; set; }
}
