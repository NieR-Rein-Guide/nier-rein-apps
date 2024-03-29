using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMGachaMedalTable : TableBase<EntityMGachaMedal>
{
    private readonly Func<EntityMGachaMedal, int> primaryIndexSelector;

    public EntityMGachaMedalTable(EntityMGachaMedal[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.GachaMedalId;
    }

    public EntityMGachaMedal FindByGachaMedalId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
}
