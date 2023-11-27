using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMQuestSceneNotConfirmTitleDialog))]
public class EntityMQuestSceneNotConfirmTitleDialog
{
    [Key(0)]
    public int QuestSceneId { get; set; }
}
