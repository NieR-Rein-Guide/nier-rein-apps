using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMLibraryMovieTable : TableBase<EntityMLibraryMovie>
{
    private readonly Func<EntityMLibraryMovie, int> primaryIndexSelector;

    public EntityMLibraryMovieTable(EntityMLibraryMovie[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.LibraryMovieId;
    }
}
