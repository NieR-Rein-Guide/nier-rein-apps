using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMPvpSeasonGroupingTable : TableBase<EntityMPvpSeasonGrouping>
{
    private readonly Func<EntityMPvpSeasonGrouping, (int, int)> primaryIndexSelector;

    public EntityMPvpSeasonGroupingTable(EntityMPvpSeasonGrouping[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.PvpSeasonGroupingId, element.GroupId);
    }
}
