using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMBattleAttributeDamageCoefficientDefineTable : TableBase<EntityMBattleAttributeDamageCoefficientDefine>
{
    private readonly Func<EntityMBattleAttributeDamageCoefficientDefine, BattleSchemeType> primaryIndexSelector;

    public EntityMBattleAttributeDamageCoefficientDefineTable(EntityMBattleAttributeDamageCoefficientDefine[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.BattleSchemeType;
    }

    public EntityMBattleAttributeDamageCoefficientDefine FindByBattleSchemeType(BattleSchemeType key) => FindUniqueCore(data, primaryIndexSelector, Comparer<BattleSchemeType>.Default, key);
}
