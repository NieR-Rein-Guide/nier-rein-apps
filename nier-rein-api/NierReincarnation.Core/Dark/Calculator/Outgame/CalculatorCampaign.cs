using System;
using System.Collections.Generic;
using System.Linq;
using NierReincarnation.Core.Dark.Component.Story;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.View.UserInterface;
using NierReincarnation.Core.Dark.View.UserInterface.Outgame;
using NierReincarnation.Core.Subsystem.Calculator.Outgame;

namespace NierReincarnation.Core.Dark.Calculator.Outgame
{
    public static class CalculatorCampaign
    {
        public static List<DataCampaign> CreateDataQuestCampaign(IQuest quest)
        {
            return CreateDataQuestCampaign(group => IsValidQuestCampaign(group, quest));
        }

        private static List<DataCampaign> CreateDataQuestCampaign(Func<EntityMQuestCampaignTargetGroup, bool> isTargetQuestCampaign)
        {
            var campaignTable = DatabaseDefine.Master.EntityMQuestCampaignTable;
            var campaignTargetGroupTable = DatabaseDefine.Master.EntityMQuestCampaignTargetGroupTable;
            var campaignEffectGroupTable = DatabaseDefine.Master.EntityMQuestCampaignEffectGroupTable;

            var currentCampaigns = campaignTable.All.Where(x => CalculatorDateTime.IsWithinThePeriod(x.StartDatetime, x.EndDatetime));

            var result = new List<DataCampaign>();
            foreach (var campaign in currentCampaigns)
            {
                var targetGroupRange = campaignTargetGroupTable.FindRangeByQuestCampaignTargetGroupIdAndQuestCampaignTargetIndex((campaign.QuestCampaignTargetGroupId, int.MinValue), (campaign.QuestCampaignTargetGroupId, int.MaxValue));
                var orderedTargetGroups = targetGroupRange.Where(isTargetQuestCampaign).OrderByDescending(x => x.QuestCampaignTargetType);

                foreach (var org in orderedTargetGroups)
                {
                    var effectGroupRange = campaignEffectGroupTable.FindRangeByQuestCampaignEffectGroupIdAndQuestCampaignEffectType((campaign.QuestCampaignEffectGroupId, int.MinValue), (campaign.QuestCampaignEffectGroupId, int.MaxValue));

                    foreach (var effectGroup in effectGroupRange)
                        result.Add(CreateDataCampaign(campaign, effectGroup, org));
                }
            }

            return result;
        }

        private static DataQuestCampaign CreateDataCampaign(EntityMQuestCampaign entityMQuestCampaign, EntityMQuestCampaignEffectGroup entityMQuestCampaignEffectGroup, EntityMQuestCampaignTargetGroup entityMQuestCampaignTargetGroup)
        {
            var result = new DataQuestCampaign();

            if (entityMQuestCampaign != null)
            {
                result.CampaignType = CampaignType.Quest;
                result.CampaignId = entityMQuestCampaign.QuestCampaignId;
                result.EndTime = entityMQuestCampaign.EndDatetime;

                if (entityMQuestCampaignEffectGroup != null)
                {
                    result.QuestCampaignEffectType = entityMQuestCampaignEffectGroup.QuestCampaignEffectType;
                    result.EffectValue = entityMQuestCampaignEffectGroup.QuestCampaignEffectValue;

                    if (entityMQuestCampaignTargetGroup != null)
                    {
                        result.QuestCampaignTargetType = entityMQuestCampaignTargetGroup.QuestCampaignTargetType;
                        result.TargetValue = entityMQuestCampaignTargetGroup.QuestCampaignTargetValue;
                    }
                }
            };

            return result;
        }

        private static bool IsValidQuestCampaign(EntityMQuestCampaignTargetGroup entityMQuestCampaignTargetGroup, IQuest quest)
        {
            var questType = quest.QuestType;
            if (entityMQuestCampaignTargetGroup.QuestCampaignTargetType == QuestCampaignTargetType.SUB_QUEST_QUEST_ID)
            {
                if (questType != QuestType.EVENT_QUEST)
                    return false;

                return quest.QuestId == entityMQuestCampaignTargetGroup.QuestCampaignTargetValue;
            }

            if (entityMQuestCampaignTargetGroup.QuestCampaignTargetType != QuestCampaignTargetType.MAIN_QUEST_QUEST_ID)
                return false;

            if (questType != QuestType.MAIN_QUEST)
                return false;

            return quest.QuestId == entityMQuestCampaignTargetGroup.QuestCampaignTargetValue;
        }
    }
}
