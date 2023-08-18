using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMBattleNpcCostumeLotteryEffectAbilityTable : TableBase<EntityMBattleNpcCostumeLotteryEffectAbility>
{
    private readonly Func<EntityMBattleNpcCostumeLotteryEffectAbility, (long, string, int)> primaryIndexSelector;

    public EntityMBattleNpcCostumeLotteryEffectAbilityTable(EntityMBattleNpcCostumeLotteryEffectAbility[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.BattleNpcId, element.BattleNpcCostumeUuid, element.SlotNumber);
    }
}
