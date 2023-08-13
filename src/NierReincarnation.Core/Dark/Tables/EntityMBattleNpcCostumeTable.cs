using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMBattleNpcCostumeTable : TableBase<EntityMBattleNpcCostume>
{
    private readonly Func<EntityMBattleNpcCostume, (long, string)> primaryIndexSelector;

    public EntityMBattleNpcCostumeTable(EntityMBattleNpcCostume[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.BattleNpcId, element.BattleNpcCostumeUuid);
    }

    public EntityMBattleNpcCostume FindByBattleNpcIdAndBattleNpcCostumeUuid(ValueTuple<long, string> key) =>
        FindUniqueCore(data, primaryIndexSelector, Comparer<(long, string)>.Default, key);
}
