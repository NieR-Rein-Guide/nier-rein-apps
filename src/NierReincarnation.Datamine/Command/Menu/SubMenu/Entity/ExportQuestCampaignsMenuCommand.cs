using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Core.Dark.View.UserInterface;
using NierReincarnation.Datamine.Extension;

namespace NierReincarnation.Datamine.Command;

public class ExportQuestCampaignsMenuCommand : AbstractMenuCommand
{
    public override bool IsActive => Program.AppSettings.IsSetup;

    public override Task ExecuteAsync()
    {
        foreach (var questCampaign in MasterDb.EntityMQuestCampaignTable.All
            .Where(x => DateTimeExtensions.IsCurrentOrFuture(x.StartDatetime, x.EndDatetime))
            .OrderBy(x => x.SortOrder)
            .ThenBy(x => x.StartDatetime))
        {
            var effectGroup = MasterDb.EntityMQuestCampaignEffectGroupTable.All.FirstOrDefault(x => x.QuestCampaignEffectGroupId == questCampaign.QuestCampaignEffectGroupId);

            if (effectGroup == null) continue;

            var targetGroups = MasterDb.EntityMQuestCampaignTargetGroupTable.All.Where(x => x.QuestCampaignTargetGroupId == questCampaign.QuestCampaignTargetGroupId);
            var targetItemGroups = MasterDb.EntityMQuestCampaignTargetItemGroupTable.All.Where(x => x.QuestCampaignTargetItemGroupId == effectGroup.QuestCampaignTargetItemGroupId);
            var targetQuests = targetGroups.Select(x => CalculatorQuest.CreateEventQuestData(x.QuestCampaignTargetValue)).Where(x => x != null);

            foreach (var targetGroup in targetGroups.GroupBy(x => $"campaign.name.{(int)CampaignType.Quest:00}.{(int)effectGroup.QuestCampaignEffectType:00}.{(int)x.QuestCampaignTargetType:00}".Localize()))
            {
                var targetGroupOne = targetGroup.First();
                var descStr = $"campaign.description.{(int)CampaignType.Quest:00}.{(int)effectGroup.QuestCampaignEffectType:00}.{(int)targetGroupOne.QuestCampaignTargetType:00}".LocalizeWithParams((effectGroup.QuestCampaignEffectValue / 1000M) + 1);
                var targetStr = targetGroupOne.QuestCampaignTargetType.ToFormattedStr(targetGroupOne.QuestCampaignTargetValue);
                var userTargetStr = questCampaign.TargetUserStatusType != TargetUserStatusType.ALL
                    ? $"({questCampaign.TargetUserStatusType.ToFormattedStr()} players) "
                    : string.Empty;

                Console.WriteLine($"**{targetGroup.Key} - {descStr} {userTargetStr}({targetStr}) {questCampaign.ToFormattedDateStr()}**");

                foreach (var targetQuest in targetQuests.GroupBy(x => x.QuestName))
                {
                    Console.WriteLine($"{targetQuest.Key}");
                }

                foreach (var targetItemGroup in targetItemGroups)
                {
                    Console.WriteLine(CalculatorPossession.GetItemName(targetItemGroup.PossessionType, targetItemGroup.PossessionId));
                }
            }
            Console.WriteLine();
        }
        Console.WriteLine();
        Console.WriteLine();

        return Task.CompletedTask;
    }
}
