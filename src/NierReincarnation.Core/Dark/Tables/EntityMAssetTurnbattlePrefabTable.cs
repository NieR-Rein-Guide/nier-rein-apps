using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMAssetTurnbattlePrefabTable : TableBase<EntityMAssetTurnbattlePrefab>
{
    private readonly Func<EntityMAssetTurnbattlePrefab, int> primaryIndexSelector;

    public EntityMAssetTurnbattlePrefabTable(EntityMAssetTurnbattlePrefab[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.AssetTurnbattlePrefabId;
    }
}
