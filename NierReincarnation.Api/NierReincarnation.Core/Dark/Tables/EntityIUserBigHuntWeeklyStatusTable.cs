using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityIUserBigHuntWeeklyStatusTable : TableBase<EntityIUserBigHuntWeeklyStatus>
{
    private readonly Func<EntityIUserBigHuntWeeklyStatus, (long, long)> primaryIndexSelector;

    public EntityIUserBigHuntWeeklyStatusTable(EntityIUserBigHuntWeeklyStatus[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.UserId, element.BigHuntWeeklyVersion);
    }
}
