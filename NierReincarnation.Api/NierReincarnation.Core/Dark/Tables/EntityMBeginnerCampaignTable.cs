using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMBeginnerCampaignTable : TableBase<EntityMBeginnerCampaign>
{
    private readonly Func<EntityMBeginnerCampaign, int> primaryIndexSelector;

    public EntityMBeginnerCampaignTable(EntityMBeginnerCampaign[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.BeginnerCampaignId;
    }

    public EntityMBeginnerCampaign FindByBeginnerCampaignId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
}
