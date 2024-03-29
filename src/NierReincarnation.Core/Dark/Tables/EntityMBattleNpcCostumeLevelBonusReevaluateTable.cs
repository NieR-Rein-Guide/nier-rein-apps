using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMBattleNpcCostumeLevelBonusReevaluateTable : TableBase<EntityMBattleNpcCostumeLevelBonusReevaluate>
{
    private readonly Func<EntityMBattleNpcCostumeLevelBonusReevaluate, long> primaryIndexSelector;

    public EntityMBattleNpcCostumeLevelBonusReevaluateTable(EntityMBattleNpcCostumeLevelBonusReevaluate[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.BattleNpcId;
    }
}
