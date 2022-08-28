using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_library_movie_category")]
    public class EntityMLibraryMovieCategory
    {
        [Key(0)]
        public int LibraryMovieCategoryId { get; set; } // 0x10
        [Key(1)]
        public int NameLibraryTextId { get; set; } // 0x14
        [Key(2)]
        public int SortOrder { get; set; } // 0x18
    }
}