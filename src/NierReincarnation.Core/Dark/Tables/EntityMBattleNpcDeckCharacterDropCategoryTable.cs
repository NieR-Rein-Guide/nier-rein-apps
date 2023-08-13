using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMBattleNpcDeckCharacterDropCategoryTable : TableBase<EntityMBattleNpcDeckCharacterDropCategory>
{
    private readonly Func<EntityMBattleNpcDeckCharacterDropCategory, (long, string)> primaryIndexSelector;

    public EntityMBattleNpcDeckCharacterDropCategoryTable(EntityMBattleNpcDeckCharacterDropCategory[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.BattleNpcId, element.BattleNpcDeckCharacterUuid);
    }

    public EntityMBattleNpcDeckCharacterDropCategory FindByBattleNpcIdAndBattleNpcDeckCharacterUuid(ValueTuple<long, string> key) =>
        FindUniqueCore(data, primaryIndexSelector, Comparer<(long, string)>.Default, key);
}
