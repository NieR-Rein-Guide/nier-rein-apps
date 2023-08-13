using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMLoginBonusStampTable : TableBase<EntityMLoginBonusStamp>
{
    private readonly Func<EntityMLoginBonusStamp, (int, int, int)> primaryIndexSelector;

    public EntityMLoginBonusStampTable(EntityMLoginBonusStamp[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.LoginBonusId, element.LowerPageNumber, element.StampNumber);
    }
}
