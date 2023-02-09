using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_library_main_quest_group")]
    public class EntityMLibraryMainQuestGroup
    {
        [Key(0)]
        public int LibraryMainQuestGroupId { get; set; } // 0x10
        [Key(1)]
        public int MainQuestChapterId { get; set; } // 0x14
        [Key(2)]
        public int SortOrder { get; set; } // 0x18
        [Key(3)]
        public int ChapterTextAssetId { get; set; } // 0x1C
        [Key(4)]
        public int FirstStillAssetOrder { get; set; } // 0x20
        [Key(5)]
        public int SecondStillAssetOrder { get; set; } // 0x24
    }
}