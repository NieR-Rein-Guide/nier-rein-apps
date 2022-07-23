using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMComebackCampaignTable : TableBase<EntityMComebackCampaign> // TypeDefIndex: 11987
    {
        // Fields
        private readonly Func<EntityMComebackCampaign, int> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2D392D0 Offset: 0x2D392D0 VA: 0x2D392D0
        public EntityMComebackCampaignTable(EntityMComebackCampaign[] sortedData):base(sortedData)
        {
            primaryIndexSelector = campaign => campaign.ComebackCampaignId;
        }

        // RVA: 0x2D393D0 Offset: 0x2D393D0 VA: 0x2D393D0
        public EntityMComebackCampaign FindByComebackCampaignId(int key)
        {
            foreach(var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }
    }
}
