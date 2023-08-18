using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMBattleNpcCostumeLotteryEffectStatusUpTable : TableBase<EntityMBattleNpcCostumeLotteryEffectStatusUp>
{
    private readonly Func<EntityMBattleNpcCostumeLotteryEffectStatusUp, (long, string, StatusCalculationType)> primaryIndexSelector;

    public EntityMBattleNpcCostumeLotteryEffectStatusUpTable(EntityMBattleNpcCostumeLotteryEffectStatusUp[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.BattleNpcId, element.BattleNpcCostumeUuid, element.StatusCalculationType);
    }
}
