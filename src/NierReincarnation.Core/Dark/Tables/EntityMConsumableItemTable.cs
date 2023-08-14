using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMConsumableItemTable : TableBase<EntityMConsumableItem>
{
    private readonly Func<EntityMConsumableItem, int> primaryIndexSelector;

    public EntityMConsumableItemTable(EntityMConsumableItem[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.ConsumableItemId;
    }

    public EntityMConsumableItem FindByConsumableItemId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
}
