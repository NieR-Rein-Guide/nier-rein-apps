using System;
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
        public static DataCampaigns CreateDataQuestCampaign(IQuest quest)
        {
            return CreateDataQuestCampaign(group => IsValidQuestCampaign(group, quest));
        }

        public static DataCampaigns CreateDataQuestCampaignAll(IQuest quest)
        {
            return CreateDataQuestCampaign(group => IsValidQuestCampaignAll(group, quest));
        }

        private static DataCampaigns CreateDataQuestCampaign(Func<EntityMQuestCampaignTargetGroup, bool> isTargetQuestCampaign)
        {
            var userId = CalculatorStateUser.GetUserId();
            var isBeginner = CalculatorBeginner.IsTargetUser(userId);
            var isComeback = CalculatorComeback.IsTargetUser(userId);

            var campaignTable = DatabaseDefine.Master.EntityMQuestCampaignTable;
            var campaignTargetGroupTable = DatabaseDefine.Master.EntityMQuestCampaignTargetGroupTable;
            var campaignEffectGroupTable = DatabaseDefine.Master.EntityMQuestCampaignEffectGroupTable;

            var currentCampaigns = campaignTable.All
                .Where(x => CalculatorDateTime.IsWithinThePeriod(x.StartDatetime, x.EndDatetime))
                .Where(x => IsValidCampaign(userId, x.StartDatetime, x.EndDatetime, x.TargetUserStatusType));

            var result = new DataCampaigns();
            foreach (var campaign in currentCampaigns)
            {
                var targetGroupRange = campaignTargetGroupTable.FindRangeByQuestCampaignTargetGroupIdAndQuestCampaignTargetIndex((campaign.QuestCampaignTargetGroupId, int.MinValue), (campaign.QuestCampaignTargetGroupId, int.MaxValue));
                var orderedTargetGroups = targetGroupRange.Where(isTargetQuestCampaign).OrderByDescending(x => x.QuestCampaignTargetType);

                foreach (var targetGroup in orderedTargetGroups)
                {
                    var effectGroupRange = campaignEffectGroupTable.FindRangeByQuestCampaignEffectGroupIdAndQuestCampaignEffectType((campaign.QuestCampaignEffectGroupId, QuestCampaignEffectType.UNKNOWN), (campaign.QuestCampaignEffectGroupId, QuestCampaignEffectType.DROP_ITEM_ADD));

                    foreach (var effectGroup in effectGroupRange)
                    {
                        var dataCampaign = CreateDataCampaign(userId, campaign, effectGroup, targetGroup);

                        result.TotalCampaignList.Add(dataCampaign);
                        if (!IsSpecialCampaign(dataCampaign))
                        {
                            result.StandardCampaignList.Add(dataCampaign);
                            continue;
                        }

                        if (isBeginner && dataCampaign.TargetUserStatusType == TargetUserStatusType.BEGINNER ||
                           isComeback && dataCampaign.TargetUserStatusType == TargetUserStatusType.COMEBACK)
                            result.SpecialCampaignList.Add(dataCampaign);
                    }
                }
            }

            result.StandardCampaignList.Sort(CompareCampaignDataSortOrder);
            result.SpecialCampaignList.Sort(CompareCampaignDataSortOrder);

            return result;
        }

        public static bool IsValidCampaign(long userId, long campaignStartUnixTime, long campaignEndUnixTime, TargetUserStatusType targetUserStatusType)
        {
            // CUSTOM: Use IsSpecialCampaign overload instead of duplicated logic
            if (!IsSpecialCampaign(targetUserStatusType))
                return true;

            if (targetUserStatusType != TargetUserStatusType.COMEBACK &&
                targetUserStatusType != TargetUserStatusType.BEGINNER)
                return false;

            var campaignTime = targetUserStatusType == TargetUserStatusType.COMEBACK ?
                CalculatorComeback.GetComeBackDateTime(userId) :
                CalculatorBeginner.GetBeginnerDateTime(userId);

            if (campaignTime == 0)
                return false;

            return campaignStartUnixTime <= campaignTime && campaignTime <= campaignEndUnixTime;
        }

        public static bool IsSpecialCampaign(DataCampaign dataCampaign)
        {
            // CUSTOM: Use IsSpecialCampaign overload instead of duplicated logic
            return IsSpecialCampaign(dataCampaign.TargetUserStatusType);
        }

        private static bool IsSpecialCampaign(TargetUserStatusType targetUserStatusType)
        {
            return ((int)targetUserStatusType | 1) == (int)TargetUserStatusType.BEGINNER;
        }

        private static int CompareCampaignDataSortOrder(DataCampaign campaignData1, DataCampaign campaignData2)
        {
            if (campaignData1.SortOrder < campaignData2.SortOrder)
                return -1;

            return campaignData2.SortOrder < campaignData1.SortOrder ? 1 : 0;
        }

        private static DataQuestCampaign CreateDataCampaign(long userId, EntityMQuestCampaign entityMQuestCampaign, EntityMQuestCampaignEffectGroup entityMQuestCampaignEffectGroup, EntityMQuestCampaignTargetGroup entityMQuestCampaignTargetGroup)
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

        private static bool IsValidQuestCampaignAll(EntityMQuestCampaignTargetGroup entityMQuestCampaignTargetGroup, IQuest quest)
        {
            switch (entityMQuestCampaignTargetGroup.QuestCampaignTargetType)
            {
                case QuestCampaignTargetType.WHOLE_QUEST:
                    return true;

                case QuestCampaignTargetType.QUEST_TYPE:
                    return (int)quest.QuestType == entityMQuestCampaignTargetGroup.QuestCampaignTargetValue;

                case QuestCampaignTargetType.EVENT_QUEST_TYPE:
                    if (quest.QuestType != QuestType.EVENT_QUEST)
                        return false;

                    return (int)(quest as EventQuest).EntityQuestChapter.EventQuestType ==
                           entityMQuestCampaignTargetGroup.QuestCampaignTargetValue;

                case QuestCampaignTargetType.MAIN_QUEST_CHAPTER_ID:
                    if (quest.QuestType != QuestType.MAIN_QUEST)
                        return false;

                    return quest.ChapterId == entityMQuestCampaignTargetGroup.QuestCampaignTargetValue;

                case QuestCampaignTargetType.MAIN_QUEST_QUEST_ID:
                    if (quest.QuestType != QuestType.MAIN_QUEST)
                        return false;

                    return quest.QuestId == entityMQuestCampaignTargetGroup.QuestCampaignTargetValue;

                case QuestCampaignTargetType.SUB_QUEST_CHAPTER_ID:
                    if (quest.QuestType != QuestType.EVENT_QUEST)
                        return false;

                    return quest.ChapterId == entityMQuestCampaignTargetGroup.QuestCampaignTargetValue;

                case QuestCampaignTargetType.SUB_QUEST_QUEST_ID:
                    if (quest.QuestType != QuestType.EVENT_QUEST)
                        return false;

                    return quest.QuestId == entityMQuestCampaignTargetGroup.QuestCampaignTargetValue;

                default:
                    return false;
            }
        }
    }
}
