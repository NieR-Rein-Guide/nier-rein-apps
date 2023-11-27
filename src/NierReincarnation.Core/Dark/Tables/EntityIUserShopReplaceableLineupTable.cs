using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityIUserShopReplaceableLineupTable : TableBase<EntityIUserShopReplaceableLineup>
{
    private readonly Func<EntityIUserShopReplaceableLineup, (long, int)> primaryIndexSelector;

    public EntityIUserShopReplaceableLineupTable(EntityIUserShopReplaceableLineup[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.UserId, element.SlotNumber);
    }

    public RangeView<EntityIUserShopReplaceableLineup> FindRangeByUserIdAndSlotNumber(ValueTuple<long, int> min, ValueTuple<long, int> max, bool ascendant = true) =>
        FindUniqueRangeCore(data, primaryIndexSelector, Comparer<(long, int)>.Default, min, max, ascendant);
}
