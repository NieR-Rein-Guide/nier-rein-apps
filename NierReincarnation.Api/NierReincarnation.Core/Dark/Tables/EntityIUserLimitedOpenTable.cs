using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityIUserLimitedOpenTable : TableBase<EntityIUserLimitedOpen>
{
    private readonly Func<EntityIUserLimitedOpen, (long, LimitedOpenTargetType, int)> primaryIndexSelector;

    public EntityIUserLimitedOpenTable(EntityIUserLimitedOpen[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.UserId, element.LimitedOpenTargetType, element.TargetId);
    }

    public EntityIUserLimitedOpen FindByUserIdAndLimitedOpenTargetTypeAndTargetId(ValueTuple<long, LimitedOpenTargetType, int> key) =>
        FindUniqueCore(data, primaryIndexSelector, Comparer<(long, LimitedOpenTargetType, int)>.Default, key);
}
