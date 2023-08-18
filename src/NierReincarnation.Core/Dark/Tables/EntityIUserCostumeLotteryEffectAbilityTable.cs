using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityIUserCostumeLotteryEffectAbilityTable : TableBase<EntityIUserCostumeLotteryEffectAbility>
{
    private readonly Func<EntityIUserCostumeLotteryEffectAbility, (long, string, int)> primaryIndexSelector;
    private readonly Func<EntityIUserCostumeLotteryEffectAbility, (long, string)> secondaryIndexSelector;

    public EntityIUserCostumeLotteryEffectAbilityTable(EntityIUserCostumeLotteryEffectAbility[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.UserId, element.UserCostumeUuid, element.SlotNumber);
        secondaryIndexSelector = element => (element.UserId, element.UserCostumeUuid);
    }

    public RangeView<EntityIUserCostumeLotteryEffectAbility> FindByUserIdAndUserCostumeUuid(ValueTuple<long, string> key) =>
        FindManyCore(data, secondaryIndexSelector, Comparer<(long, string)>.Default, key);
}
