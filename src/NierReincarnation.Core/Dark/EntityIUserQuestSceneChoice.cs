using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityIUserQuestSceneChoice))]
public class EntityIUserQuestSceneChoice
{
    [Key(0)]
    public long UserId { get; set; }

    [Key(1)]
    public int QuestSceneChoiceGroupingId { get; set; }

    [Key(2)]
    public int QuestSceneChoiceEffectId { get; set; }

    [Key(3)]
    public long LatestVersion { get; set; }
}
