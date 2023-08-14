using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_library_movie_category")]
public class EntityMLibraryMovieCategory
{
    [Key(0)]
    public int LibraryMovieCategoryId { get; set; }

    [Key(1)]
    public int NameLibraryTextId { get; set; }

    [Key(2)]
    public int SortOrder { get; set; }
}
