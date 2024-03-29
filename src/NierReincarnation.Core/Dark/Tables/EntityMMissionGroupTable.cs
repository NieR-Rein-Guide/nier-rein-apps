using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMMissionGroupTable : TableBase<EntityMMissionGroup>
{
    private readonly Func<EntityMMissionGroup, int> primaryIndexSelector;

    public EntityMMissionGroupTable(EntityMMissionGroup[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.MissionGroupId;
    }

    public EntityMMissionGroup FindByMissionGroupId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
}
