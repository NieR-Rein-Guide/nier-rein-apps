using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMBattleNpcDeckTable : TableBase<EntityMBattleNpcDeck>
{
    private readonly Func<EntityMBattleNpcDeck, (long, DeckType, int)> primaryIndexSelector;

    public EntityMBattleNpcDeckTable(EntityMBattleNpcDeck[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.BattleNpcId, element.DeckType, element.BattleNpcDeckNumber);
    }

    public EntityMBattleNpcDeck FindByBattleNpcIdAndDeckTypeAndBattleNpcDeckNumber(ValueTuple<long, DeckType, int> key) =>
        FindUniqueCore(data, primaryIndexSelector, Comparer<(long, DeckType, int)>.Default, key);
}
