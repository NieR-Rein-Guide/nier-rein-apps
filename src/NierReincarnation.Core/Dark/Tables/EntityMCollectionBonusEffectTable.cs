using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMCollectionBonusEffectTable : TableBase<EntityMCollectionBonusEffect>
{
    private readonly Func<EntityMCollectionBonusEffect, (int, CollectionBonusEffectType)> primaryIndexSelector;

    public EntityMCollectionBonusEffectTable(EntityMCollectionBonusEffect[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.CollectionBonusEffectId, element.CollectionBonusEffectType);
    }

    public EntityMCollectionBonusEffect FindByCollectionBonusEffectIdAndCollectionBonusEffectType(ValueTuple<int, CollectionBonusEffectType> key) =>
        FindUniqueCore(data, primaryIndexSelector, Comparer<(int, CollectionBonusEffectType)>.Default, key);

    public RangeView<EntityMCollectionBonusEffect> FindRangeByCollectionBonusEffectIdAndCollectionBonusEffectType(ValueTuple<int, CollectionBonusEffectType> min, ValueTuple<int, CollectionBonusEffectType> max, bool ascendant = true) =>
        FindUniqueRangeCore(data, primaryIndexSelector, Comparer<(int, CollectionBonusEffectType)>.Default, min, max, ascendant);
}
