using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMBeginnerCampaignTable : TableBase<EntityMBeginnerCampaign> // TypeDefIndex: 11881
    {
        // Fields
        private readonly Func<EntityMBeginnerCampaign, int> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2D32130 Offset: 0x2D32130 VA: 0x2D32130
        public EntityMBeginnerCampaignTable(EntityMBeginnerCampaign[] sortedData):base(sortedData)
        {
            primaryIndexSelector = campaign => campaign.BeginnerCampaignId;
        }

        // RVA: 0x2D32230 Offset: 0x2D32230 VA: 0x2D32230
        public EntityMBeginnerCampaign FindByBeginnerCampaignId(int key)
        {
            foreach(var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }
    }
}
