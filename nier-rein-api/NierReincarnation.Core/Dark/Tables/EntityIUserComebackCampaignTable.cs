using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityIUserComebackCampaignTable : TableBase<EntityIUserComebackCampaign> // TypeDefIndex: 12739
    {
        // Fields
        private readonly Func<EntityIUserComebackCampaign, long> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x37376FC Offset: 0x37376FC VA: 0x37376FC
        public EntityIUserComebackCampaignTable(EntityIUserComebackCampaign[] sortedData):base(sortedData)
        {
            primaryIndexSelector = campaign => campaign.UserId;
        }

        // RVA: 0x37377FC Offset: 0x37377FC VA: 0x37377FC
        public EntityIUserComebackCampaign FindByUserId(long key)
        {
            foreach(var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }
    }
}
