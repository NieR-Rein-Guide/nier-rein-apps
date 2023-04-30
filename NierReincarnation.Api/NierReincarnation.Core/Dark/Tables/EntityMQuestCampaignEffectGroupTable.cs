using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMQuestCampaignEffectGroupTable : TableBase<EntityMQuestCampaignEffectGroup>
    {
        private readonly Func<EntityMQuestCampaignEffectGroup, (int, QuestCampaignEffectType)> primaryIndexSelector;

        public EntityMQuestCampaignEffectGroupTable(EntityMQuestCampaignEffectGroup[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.QuestCampaignEffectGroupId, element.QuestCampaignEffectType);
        }

        public RangeView<EntityMQuestCampaignEffectGroup> FindRangeByQuestCampaignEffectGroupIdAndQuestCampaignEffectType(ValueTuple<int, QuestCampaignEffectType> min, ValueTuple<int, QuestCampaignEffectType> max, bool ascendant = true) =>
            FindUniqueRangeCore(data, primaryIndexSelector, Comparer<(int, QuestCampaignEffectType)>.Default, min, max, ascendant);
    }
}
