using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_library_main_quest_story")]
    public class EntityMLibraryMainQuestStory
    {
        [Key(0)]
        public int LibraryMainQuestGroupId { get; set; } // 0x10

        [Key(1)]
        public int SortOrder { get; set; } // 0x14

        [Key(2)]
        public int RecollectionSceneId { get; set; } // 0x18

        [Key(3)]
        public int LibraryMainQuestStoryUnlockEvaluateConditionId { get; set; } // 0x1C

        [Key(4)]
        public int TextAssetId { get; set; } // 0x20
    }
}
