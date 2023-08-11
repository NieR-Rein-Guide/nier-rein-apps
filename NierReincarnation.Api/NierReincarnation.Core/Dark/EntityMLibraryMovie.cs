using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_library_movie")]
public class EntityMLibraryMovie
{
    [Key(0)]
    public int LibraryMovieId { get; set; }

    [Key(1)]
    public int TitleLibraryTextId { get; set; }

    [Key(2)]
    public int LibraryMovieCategoryId { get; set; }

    [Key(3)]
    public int SortOrder { get; set; }

    [Key(4)]
    public int LibraryMovieUnlockConditionId { get; set; }

    [Key(5)]
    public int LibraryMovieUnlockEvaluateConditionId { get; set; }

    [Key(6)]
    public int MovieId { get; set; }
}
