using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMCostumeProperAttributeHpBonusTable : TableBase<EntityMCostumeProperAttributeHpBonus>
{
    private readonly Func<EntityMCostumeProperAttributeHpBonus, int> primaryIndexSelector;

    public EntityMCostumeProperAttributeHpBonusTable(EntityMCostumeProperAttributeHpBonus[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.CostumeId;
    }

    public bool TryFindByCostumeId(int key, out EntityMCostumeProperAttributeHpBonus result) => TryFindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key, out result);
}
