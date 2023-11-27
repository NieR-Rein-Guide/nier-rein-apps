using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("entity_m_quest_scene_picture_book_replace")]
public class EntityMQuestScenePictureBookReplace
{
    [Key(0)]
    public int QuestSceneId { get; set; }

    [Key(1)]
    public int PictureBookNameQuestTextId { get; set; }

    [Key(2)]
    public bool IsExcludeSubflow { get; set; }

    [Key(3)]
    public bool IsExcludeRecollection { get; set; }
}
