using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMPartsRarityTable : TableBase<EntityMPartsRarity>
{
    private readonly Func<EntityMPartsRarity, RarityType> primaryIndexSelector;

    public EntityMPartsRarityTable(EntityMPartsRarity[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.RarityType;
    }

    public EntityMPartsRarity FindByRarityType(RarityType key) => FindUniqueCore(data, primaryIndexSelector, Comparer<RarityType>.Default, key);
}
