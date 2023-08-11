using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityIUserComebackCampaignTable : TableBase<EntityIUserComebackCampaign>
{
    private readonly Func<EntityIUserComebackCampaign, long> primaryIndexSelector;

    public EntityIUserComebackCampaignTable(EntityIUserComebackCampaign[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.UserId;
    }

    public EntityIUserComebackCampaign FindByUserId(long key) => FindUniqueCore(data, primaryIndexSelector, Comparer<long>.Default, key);
}
