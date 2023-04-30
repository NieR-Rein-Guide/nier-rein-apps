using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMComebackCampaignTable : TableBase<EntityMComebackCampaign>
    {
        private readonly Func<EntityMComebackCampaign, int> primaryIndexSelector;

        public EntityMComebackCampaignTable(EntityMComebackCampaign[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.ComebackCampaignId;
        }

        public EntityMComebackCampaign FindByComebackCampaignId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
    }
}
