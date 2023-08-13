using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_library_main_quest_story")]
public class EntityMLibraryMainQuestStory
{
    [Key(0)]
    public int LibraryMainQuestGroupId { get; set; }

    [Key(1)]
    public int SortOrder { get; set; }

    [Key(2)]
    public int RecollectionSceneId { get; set; }

    [Key(3)]
    public int LibraryMainQuestStoryUnlockEvaluateConditionId { get; set; }

    [Key(4)]
    public int TextAssetId { get; set; }
}
