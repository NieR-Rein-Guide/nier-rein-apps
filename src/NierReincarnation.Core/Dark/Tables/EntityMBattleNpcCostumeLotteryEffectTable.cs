using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMBattleNpcCostumeLotteryEffectTable : TableBase<EntityMBattleNpcCostumeLotteryEffect>
{
    private readonly Func<EntityMBattleNpcCostumeLotteryEffect, (long, string, int)> primaryIndexSelector;

    public EntityMBattleNpcCostumeLotteryEffectTable(EntityMBattleNpcCostumeLotteryEffect[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.BattleNpcId, element.BattleNpcCostumeUuid, element.SlotNumber);
    }
}
