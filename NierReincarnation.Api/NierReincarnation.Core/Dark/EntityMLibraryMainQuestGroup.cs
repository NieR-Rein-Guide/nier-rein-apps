using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_library_main_quest_group")]
    public class EntityMLibraryMainQuestGroup
    {
        [Key(0)]
        public int LibraryMainQuestGroupId { get; set; }

        [Key(1)]
        public int MainQuestChapterId { get; set; }

        [Key(2)]
        public int SortOrder { get; set; }

        [Key(3)]
        public int ChapterTextAssetId { get; set; }

        [Key(4)]
        public int FirstStillAssetOrder { get; set; }

        [Key(5)]
        public int SecondStillAssetOrder { get; set; }
    }
}
