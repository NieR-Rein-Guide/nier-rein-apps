using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Datamine.Extension;

namespace NierReincarnation.Datamine.Command;

public class ExportCostumeStoryMenuCommand : AbstractMenuCommand<ExportCostumeStoryMenuCommandArg>
{
    public override bool IsActive => Program.AppSettings.IsSetup;

    public ExportCostumeStoryMenuCommand(ExportCostumeStoryMenuCommandArg arg) : base(arg) { }

    public override Task ExecuteAsync(ExportCostumeStoryMenuCommandArg arg)
    {
        var darkCostume = MasterDb.EntityMCostumeTable.FindByCostumeId(arg.CostumeId);
        var characterName = CalculatorCharacter.CharacterName(darkCostume.CharacterId);
        var costumeName = CalculatorCostume.CostumeName(darkCostume.CostumeId);
        var costumeDescription = CalculatorCostume.CostumeDescription(darkCostume.CostumeId);

        Console.WriteLine($"__**{characterName} ~ {costumeName} ({darkCostume.RarityType.ToFormattedStr(false)})**__");
        Console.WriteLine();

        foreach (var line in costumeDescription.HtmlToDiscordText().Split("\\n"))
        {
            {
                Console.WriteLine(line);
            }
        }

        return Task.CompletedTask;
    }
}

public class ExportCostumeStoryMenuCommandArg
{
    public int CostumeId { get; init; }
}
