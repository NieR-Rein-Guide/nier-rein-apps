using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityIUserCharacterBoardStatusUpTable : TableBase<EntityIUserCharacterBoardStatusUp>
{
    private readonly Func<EntityIUserCharacterBoardStatusUp, (long, int, StatusCalculationType)> primaryIndexSelector;

    public EntityIUserCharacterBoardStatusUpTable(EntityIUserCharacterBoardStatusUp[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.UserId, element.CharacterId, element.StatusCalculationType);
    }

    public EntityIUserCharacterBoardStatusUp FindByUserIdAndCharacterIdAndStatusCalculationType(ValueTuple<long, int, StatusCalculationType> key) =>
        FindUniqueCore(data, primaryIndexSelector, Comparer<(long, int, StatusCalculationType)>.Default, key);

    public RangeView<EntityIUserCharacterBoardStatusUp> FindRangeByUserIdAndCharacterIdAndStatusCalculationType(ValueTuple<long, int, StatusCalculationType> min, ValueTuple<long, int, StatusCalculationType> max, bool ascendant = true) =>
        FindUniqueRangeCore(data, primaryIndexSelector, Comparer<(long, int, StatusCalculationType)>.Default, min, max, ascendant);
}
