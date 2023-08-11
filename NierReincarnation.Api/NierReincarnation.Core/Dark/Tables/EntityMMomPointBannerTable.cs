using NierReincarnation.Core.MasterMemory;
using System;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMMomPointBannerTable : TableBase<EntityMMomPointBanner>
{
    private readonly Func<EntityMMomPointBanner, int> primaryIndexSelector;

    public EntityMMomPointBannerTable(EntityMMomPointBanner[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.MomPointBannerId;
    }
}
