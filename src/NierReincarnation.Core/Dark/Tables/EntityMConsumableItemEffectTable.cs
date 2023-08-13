using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMConsumableItemEffectTable : TableBase<EntityMConsumableItemEffect>
{
    private readonly Func<EntityMConsumableItemEffect, int> primaryIndexSelector;

    public EntityMConsumableItemEffectTable(EntityMConsumableItemEffect[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.ConsumableItemId;
    }

    public EntityMConsumableItemEffect FindByConsumableItemId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
}
