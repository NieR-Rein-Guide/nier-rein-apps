using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMBattleEnemySizeTypeConfigTable : TableBase<EntityMBattleEnemySizeTypeConfig>
{
    private readonly Func<EntityMBattleEnemySizeTypeConfig, (CostumeAssetCategoryType, int)> primaryIndexSelector;

    public EntityMBattleEnemySizeTypeConfigTable(EntityMBattleEnemySizeTypeConfig[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.CostumeAssetCategoryType, element.ActorSkeletonId);
    }

    public bool TryFindByCostumeAssetCategoryTypeAndActorSkeletonId(ValueTuple<CostumeAssetCategoryType, int> key, out EntityMBattleEnemySizeTypeConfig result) =>
        TryFindUniqueCore(data, primaryIndexSelector, Comparer<(CostumeAssetCategoryType, int)>.Default, key, out result);
}
