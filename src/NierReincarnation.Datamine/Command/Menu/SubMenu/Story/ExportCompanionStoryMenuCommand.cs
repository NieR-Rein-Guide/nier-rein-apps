using NierReincarnation.Core.Subsystem.Calculator.Outgame;
using NierReincarnation.Datamine.Extension;

namespace NierReincarnation.Datamine.Command;

public class ExportCompanionStoryMenuCommand : AbstractMenuCommand<ExportCompanionStoryMenuCommandArg>
{
    public override bool IsActive => Program.AppSettings.IsSetup;

    public ExportCompanionStoryMenuCommand(ExportCompanionStoryMenuCommandArg arg) : base(arg) { }

    public override Task ExecuteAsync(ExportCompanionStoryMenuCommandArg arg)
    {
        var darkCompanion = MasterDb.EntityMCompanionTable.FindByCompanionId(arg.CompanionId);
        var companionName = CalculatorCompanion.CompanionName(darkCompanion.CompanionId);
        var companionDescription = CalculatorCompanion.CompanionDescription(darkCompanion.CompanionId);

        Console.WriteLine($"{companionName} ({darkCompanion.AttributeType.ToFormattedStr()})".ToHeader2());
        Console.WriteLine();

        foreach (var line in companionDescription.HtmlToDiscordText().Split("\\n"))
        {
            Console.WriteLine(line);
        }
        Console.WriteLine();
        Console.WriteLine();

        return Task.CompletedTask;
    }
}

public class ExportCompanionStoryMenuCommandArg
{
    public int CompanionId { get; init; }
}
