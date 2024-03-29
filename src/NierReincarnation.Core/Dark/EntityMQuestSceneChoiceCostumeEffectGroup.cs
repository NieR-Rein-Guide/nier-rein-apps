using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMQuestSceneChoiceCostumeEffectGroup))]
public class EntityMQuestSceneChoiceCostumeEffectGroup
{
    [Key(0)]
    public int QuestSceneChoiceCostumeEffectGroupId { get; set; }

    [Key(1)]
    public int SortOrder { get; set; }

    [Key(2)]
    public int CostumeId { get; set; }
}
