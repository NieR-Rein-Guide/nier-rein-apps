using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMQuestReleaseConditionUserLevel))]
public class EntityMQuestReleaseConditionUserLevel
{
    [Key(0)]
    public int QuestReleaseConditionId { get; set; }

    [Key(1)]
    public int UserLevel { get; set; }
}
