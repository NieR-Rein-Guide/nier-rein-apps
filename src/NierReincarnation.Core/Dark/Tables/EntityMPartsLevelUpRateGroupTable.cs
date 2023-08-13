using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMPartsLevelUpRateGroupTable : TableBase<EntityMPartsLevelUpRateGroup>
{
    private readonly Func<EntityMPartsLevelUpRateGroup, (int, int)> primaryIndexSelector;

    public EntityMPartsLevelUpRateGroupTable(EntityMPartsLevelUpRateGroup[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.PartsLevelUpRateGroupId, element.LevelLowerLimit);
    }

    public EntityMPartsLevelUpRateGroup FindByPartsLevelUpRateGroupIdAndLevelLowerLimit(ValueTuple<int, int> key) =>
        FindUniqueCore(data, primaryIndexSelector, Comparer<(int, int)>.Default, key);
}
