using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMQuestMissionGroup))]
public class EntityMQuestMissionGroup
{
    [Key(0)]
    public int QuestMissionGroupId { get; set; }

    [Key(1)]
    public int SortOrder { get; set; }

    [Key(2)]
    public int QuestMissionId { get; set; }
}
