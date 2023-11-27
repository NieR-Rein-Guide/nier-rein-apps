using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMQuestSceneOutgameBlendshapeMotion))]
public class EntityMQuestSceneOutgameBlendshapeMotion
{
    [Key(0)]
    public int QuestSceneId { get; set; }

    [Key(1)]
    public int ActorAnimationId { get; set; }
}
