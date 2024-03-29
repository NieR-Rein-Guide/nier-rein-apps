using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMLibraryMovieUnlockConditionTable : TableBase<EntityMLibraryMovieUnlockCondition>
{
    private readonly Func<EntityMLibraryMovieUnlockCondition, int> primaryIndexSelector;

    public EntityMLibraryMovieUnlockConditionTable(EntityMLibraryMovieUnlockCondition[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.LibraryMovieUnlockConditionId;
    }

    public EntityMLibraryMovieUnlockCondition FindByLibraryMovieUnlockConditionId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
}
