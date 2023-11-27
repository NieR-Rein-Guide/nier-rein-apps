using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMQuestReleaseConditionGroup))]
public class EntityMQuestReleaseConditionGroup
{
    [Key(0)]
    public int QuestReleaseConditionGroupId { get; set; }

    [Key(1)]
    public int SortOrder { get; set; }

    [Key(2)]
    public QuestReleaseConditionType QuestReleaseConditionType { get; set; }

    [Key(3)]
    public int QuestReleaseConditionId { get; set; }
}
