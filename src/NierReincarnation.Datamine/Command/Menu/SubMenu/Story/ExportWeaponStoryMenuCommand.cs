using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Core.Dark.View.HeadUpDisplay.Calculator;
using NierReincarnation.Datamine.Extension;

namespace NierReincarnation.Datamine.Command;

public class ExportWeaponStoryMenuCommand : AbstractMenuCommand<ExportWeaponStoryMenuCommandArg>
{
    public override bool IsActive => Program.AppSettings.IsSetup;

    public ExportWeaponStoryMenuCommand(ExportWeaponStoryMenuCommandArg arg) : base(arg) { }

    public override Task ExecuteAsync(ExportWeaponStoryMenuCommandArg arg)
    {
        var darkWeapon = MasterDb.EntityMWeaponTable.FindByWeaponId(arg.WeaponId);
        var weaponName = CalculatorWeapon.WeaponName(darkWeapon.WeaponId);
        var assetId = CalculatorWeapon.ActorAssetId(darkWeapon);
        var counter = 0;

        var darkWeaponStoryReleaseConditionGroups = MasterDb.EntityMWeaponStoryReleaseConditionGroupTable.All.Where(x => x.WeaponStoryReleaseConditionGroupId == darkWeapon.WeaponStoryReleaseConditionGroupId);

        Console.WriteLine($"{weaponName} ({darkWeapon.WeaponType.ToFormattedStr()}) ({darkWeapon.RarityType.ToFormattedStr(true)})".ToHeader2());
        Console.WriteLine();

        foreach (var darkWeaponStoryReleaseConditionGroup in darkWeaponStoryReleaseConditionGroups)
        {
            string text = $"weapon.story.{assetId.StringId}.{darkWeaponStoryReleaseConditionGroup.StoryIndex}".Localize();

            if (string.IsNullOrEmpty(text)) continue;

            var lines = text.HtmlToDiscordText().Split("\\n");

            Console.WriteLine($"Story {++counter}".ToBold());
            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        return Task.CompletedTask;
    }
}

public class ExportWeaponStoryMenuCommandArg
{
    public int WeaponId { get; init; }
}
