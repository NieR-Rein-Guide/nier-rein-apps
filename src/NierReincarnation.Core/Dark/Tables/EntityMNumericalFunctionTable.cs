using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMNumericalFunctionTable : TableBase<EntityMNumericalFunction>
{
    private readonly Func<EntityMNumericalFunction, int> primaryIndexSelector;

    public EntityMNumericalFunctionTable(EntityMNumericalFunction[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.NumericalFunctionId;
    }

    public EntityMNumericalFunction FindByNumericalFunctionId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
}
