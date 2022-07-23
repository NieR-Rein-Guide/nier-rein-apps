using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityIUserBeginnerCampaignTable : TableBase<EntityIUserBeginnerCampaign> // TypeDefIndex: 12715
    {
        // Fields
        private readonly Func<EntityIUserBeginnerCampaign, long> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2F1C8C0 Offset: 0x2F1C8C0 VA: 0x2F1C8C0
        public EntityIUserBeginnerCampaignTable(EntityIUserBeginnerCampaign[] sortedData):base(sortedData)
        {
            primaryIndexSelector = campaign => campaign.UserId;
        }

        // RVA: 0x2F1C9C0 Offset: 0x2F1C9C0 VA: 0x2F1C9C0
        public EntityIUserBeginnerCampaign FindByUserId(long key)
        {
            foreach(var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }
    }
}
