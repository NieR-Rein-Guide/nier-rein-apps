using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_quest_scene_outgame_blendshape_motion")]
    public class EntityMQuestSceneOutgameBlendshapeMotion
    {
        [Key(0)]
        public int QuestSceneId { get; set; } // 0x10
        [Key(1)]
        public int ActorAnimationId { get; set; } // 0x14
    }
}