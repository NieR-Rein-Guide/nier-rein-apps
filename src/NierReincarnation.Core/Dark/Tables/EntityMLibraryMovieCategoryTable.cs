using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMLibraryMovieCategoryTable : TableBase<EntityMLibraryMovieCategory>
{
    private readonly Func<EntityMLibraryMovieCategory, int> primaryIndexSelector;

    public EntityMLibraryMovieCategoryTable(EntityMLibraryMovieCategory[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.LibraryMovieCategoryId;
    }
}
