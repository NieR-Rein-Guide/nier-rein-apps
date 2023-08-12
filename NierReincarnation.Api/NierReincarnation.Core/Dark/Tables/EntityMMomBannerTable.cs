using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMMomBannerTable : TableBase<EntityMMomBanner>
{
    private readonly Func<EntityMMomBanner, int> primaryIndexSelector;

    public EntityMMomBannerTable(EntityMMomBanner[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.MomBannerId;
    }
}
