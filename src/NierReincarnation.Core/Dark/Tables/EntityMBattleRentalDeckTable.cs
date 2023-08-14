using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMBattleRentalDeckTable : TableBase<EntityMBattleRentalDeck>
{
    private readonly Func<EntityMBattleRentalDeck, int> primaryIndexSelector;

    public EntityMBattleRentalDeckTable(EntityMBattleRentalDeck[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.BattleGroupId;
    }

    public EntityMBattleRentalDeck FindByBattleGroupId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
}
