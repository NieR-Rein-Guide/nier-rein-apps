using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Core.Dark.View.HeadUpDisplay.Calculator;
using NierReincarnation.Core.Dark.View.UserInterface;
using NierReincarnation.Core.Subsystem.Calculator.Outgame;
using NierReincarnation.Datamine.Extension;

namespace NierReincarnation.Datamine.Command;

public class ExportEnhanceCampaignsMenuCommand : AbstractMenuCommand
{
    public override bool IsActive => Program.AppSettings.IsSetup;

    public override Task ExecuteAsync()
    {
        foreach (var enhanceCampaign in MasterDb.EntityMEnhanceCampaignTable.All
            .Where(x => DateTimeExtensions.IsCurrentOrFuture(x.StartDatetime, x.EndDatetime))
            .OrderBy(x => x.SortOrder)
            .ThenBy(x => x.StartDatetime))
        {
            var targetGroups = MasterDb.EntityMEnhanceCampaignTargetGroupTable.All.Where(x => x.EnhanceCampaignTargetGroupId == enhanceCampaign.EnhanceCampaignTargetGroupId);
            var targetItems = targetGroups.Select(x => x.EnhanceCampaignTargetValue).Where(x => x > 0).Distinct();

            foreach (var targetGroup in targetGroups.GroupBy(x => $"campaign.name.{(int)CampaignType.Enhance:00}.{(int)enhanceCampaign.EnhanceCampaignEffectType:00}.{(int)x.EnhanceCampaignTargetType:00}".Localize()))
            {
                var targetGroupOne = targetGroup.First();
                var descStr = $"campaign.description.{(int)CampaignType.Enhance:00}.{(int)enhanceCampaign.EnhanceCampaignEffectType:00}.{(int)targetGroupOne.EnhanceCampaignTargetType:00}".Localize();
                var targetStr = targetGroupOne.EnhanceCampaignTargetType.ToFormattedStr(targetItems.FirstOrDefault());
                var userTargetStr = enhanceCampaign.TargetUserStatusType != TargetUserStatusType.ALL
                    ? $"({enhanceCampaign.TargetUserStatusType.ToFormattedStr()} players) "
                    : string.Empty;

                Console.WriteLine($"**{targetGroup.Key} - {descStr} x{(enhanceCampaign.EnhanceCampaignEffectValue / 1000M) + 1} ({targetStr}) {userTargetStr}{enhanceCampaign.ToFormattedDateStr()}**");

                foreach (var targetItem in targetItems.GroupBy(x => GetTargetStr(targetGroupOne.EnhanceCampaignTargetType, x)))
                {
                    if (!string.IsNullOrWhiteSpace(targetItem.Key))
                    {
                        Console.WriteLine(targetItem.Key);
                    }
                }
            }
            Console.WriteLine();
        }
        Console.WriteLine();
        Console.WriteLine();

        return Task.CompletedTask;
    }

    private static string GetTargetStr(EnhanceCampaignTargetType enhanceCampaignTargetType, int value)
    {
        return enhanceCampaignTargetType switch
        {
            EnhanceCampaignTargetType.COSTUME_CHARACTER_ID => CalculatorCharacter.CharacterName(value),
            EnhanceCampaignTargetType.COSTUME_ID => CalculatorCostume.CostumeName(value),
            EnhanceCampaignTargetType.WEAPON_ID => CalculatorWeapon.WeaponName(value),
            EnhanceCampaignTargetType.PARTS_SERIES_ID => CalculatorMemory.MemorySeriesName(value),
            EnhanceCampaignTargetType.PARTS_ID => CalculatorMemory.MemoryName(value),
            EnhanceCampaignTargetType.WEAPON_ATTRIBUTE_TYPE_ID or EnhanceCampaignTargetType.COSTUME_SKILLFUL_WEAPON_TYPE_ID or EnhanceCampaignTargetType.WEAPON_TYPE_ID => string.Empty,
            EnhanceCampaignTargetType.COSTUME_ALL or EnhanceCampaignTargetType.WEAPON_ALL or EnhanceCampaignTargetType.PARTS_ALL => string.Empty,
            _ => "Unknown"
        };
    }
}
