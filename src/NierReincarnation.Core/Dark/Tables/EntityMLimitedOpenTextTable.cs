using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMLimitedOpenTextTable : TableBase<EntityMLimitedOpenText>
{
    private readonly Func<EntityMLimitedOpenText, (LimitedOpenTargetType, int)> primaryIndexSelector;

    public EntityMLimitedOpenTextTable(EntityMLimitedOpenText[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.LimitedOpenTargetType, element.TargetId);
    }

    public EntityMLimitedOpenText FindByLimitedOpenTargetTypeAndTargetId(ValueTuple<LimitedOpenTargetType, int> key) =>
        FindUniqueCore(data, primaryIndexSelector, Comparer<(LimitedOpenTargetType, int)>.Default, key);
}
