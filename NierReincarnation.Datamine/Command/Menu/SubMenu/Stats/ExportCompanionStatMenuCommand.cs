using NierReincarnation.Datamine.Model;

namespace NierReincarnation.Datamine.Command;

public class ExportCompanionStatMenuCommand : AbstractMenuCommand<ExportCompanionStatMenuCommandArg>
{
    public override bool IsActive => Program.AppSettings.IsSetup;

    public ExportCompanionStatMenuCommand(ExportCompanionStatMenuCommandArg arg) : base(arg) { }

    public override async Task ExecuteAsync(ExportCompanionStatMenuCommandArg arg)
    {
        Companion companion = await new FetchComanionCommand().ExecuteAsync(new FetchComanionCommandArg
        {
            EntityId = arg.CompanionId
        });

        Console.WriteLine(companion);
    }
}

public class ExportCompanionStatMenuCommandArg
{
    public int CompanionId { get; init; }
}
