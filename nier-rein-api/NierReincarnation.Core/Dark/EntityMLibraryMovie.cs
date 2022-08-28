using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_library_movie")]
    public class EntityMLibraryMovie
    {
        [Key(0)]
        public int LibraryMovieId { get; set; } // 0x10
        [Key(1)]
        public int TitleLibraryTextId { get; set; } // 0x14
        [Key(2)]
        public int LibraryMovieCategoryId { get; set; } // 0x18
        [Key(3)]
        public int SortOrder { get; set; } // 0x1C
        [Key(4)]
        public int LibraryMovieUnlockConditionId { get; set; } // 0x20
        [Key(5)]
        public int LibraryMovieUnlockEvaluateConditionId { get; set; } // 0x24
        [Key(6)]
        public int MovieId { get; set; } // 0x28
    }
}