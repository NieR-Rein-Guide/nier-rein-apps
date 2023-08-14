using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMThoughtTable : TableBase<EntityMThought>
{
    private readonly Func<EntityMThought, int> primaryIndexSelector;

    public EntityMThoughtTable(EntityMThought[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.ThoughtId;
    }

    public bool TryFindByThoughtId(int key, out EntityMThought result) => TryFindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key, out result);
}
