using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_quest_scene_not_confirm_title_dialog")]
public class EntityMQuestSceneNotConfirmTitleDialog
{
    [Key(0)]
    public int QuestSceneId { get; set; }
}
