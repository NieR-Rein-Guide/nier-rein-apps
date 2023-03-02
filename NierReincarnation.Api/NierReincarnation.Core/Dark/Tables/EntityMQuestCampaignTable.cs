using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMQuestCampaignTable : TableBase<EntityMQuestCampaign> // TypeDefIndex: 12131
    {
        // Fields
        private readonly Func<EntityMQuestCampaign, int> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2C57348 Offset: 0x2C57348 VA: 0x2C57348
        public EntityMQuestCampaignTable(EntityMQuestCampaign[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = campaign => campaign.QuestCampaignId;
        }
    }
}
