using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_quest_scene_outgame_blendshape_motion")]
public class EntityMQuestSceneOutgameBlendshapeMotion
{
    [Key(0)]
    public int QuestSceneId { get; set; }

    [Key(1)]
    public int ActorAnimationId { get; set; }
}
