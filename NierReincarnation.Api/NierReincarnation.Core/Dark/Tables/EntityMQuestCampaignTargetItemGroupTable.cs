using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMQuestCampaignTargetItemGroupTable : TableBase<EntityMQuestCampaignTargetItemGroup>
    {
        private readonly Func<EntityMQuestCampaignTargetItemGroup, (int,int)> primaryIndexSelector;

        public EntityMQuestCampaignTargetItemGroupTable(EntityMQuestCampaignTargetItemGroup[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.QuestCampaignTargetItemGroupId,element.TargetIndex);
        }
        
    }
}
