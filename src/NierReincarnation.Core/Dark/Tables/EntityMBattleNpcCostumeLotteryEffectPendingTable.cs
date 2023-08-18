using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMBattleNpcCostumeLotteryEffectPendingTable : TableBase<EntityMBattleNpcCostumeLotteryEffectPending>
{
    private readonly Func<EntityMBattleNpcCostumeLotteryEffectPending, (long, string)> primaryIndexSelector;

    public EntityMBattleNpcCostumeLotteryEffectPendingTable(EntityMBattleNpcCostumeLotteryEffectPending[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.BattleNpcId, element.BattleNpcCostumeUuid);
    }
}
