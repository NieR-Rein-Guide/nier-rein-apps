using NierReincarnation.Core.MasterMemory;
using System;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMQuestCampaignTargetItemGroupTable : TableBase<EntityMQuestCampaignTargetItemGroup>
    {
        private readonly Func<EntityMQuestCampaignTargetItemGroup, (int, int)> primaryIndexSelector;

        public EntityMQuestCampaignTargetItemGroupTable(EntityMQuestCampaignTargetItemGroup[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.QuestCampaignTargetItemGroupId, element.TargetIndex);
        }
    }
}
