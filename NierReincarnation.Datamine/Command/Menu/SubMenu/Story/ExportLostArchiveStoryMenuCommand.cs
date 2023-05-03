using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Datamine.Extension;

namespace NierReincarnation.Datamine.Command;

public class ExportLostArchiveStoryMenuCommand : AbstractMenuCommand<ExportLostArchiveStoryMenuCommandArg>
{
    public override bool IsActive => Program.AppSettings.IsSetup;

    public ExportLostArchiveStoryMenuCommand(ExportLostArchiveStoryMenuCommandArg arg) : base(arg) { }

    public override Task ExecuteAsync(ExportLostArchiveStoryMenuCommandArg arg)
    {
        var darkCageMemory = MasterDb.EntityMCageMemoryTable.FindByCageMemoryId(arg.CageMemoryId);
        var number = $"cage.memory.library.title.{darkCageMemory.CageMemoryAssetId:D6}".Localize();
        var title = $"cage.memory.title.{darkCageMemory.CageMemoryAssetId:D6}".Localize();
        var description = $"cage.memory.description.{darkCageMemory.CageMemoryAssetId:D6}".Localize();

        Console.WriteLine($"__**{number} ~ {title}**__");
        Console.WriteLine();

        foreach (var line in description.HtmlToDiscordText().Split("\\n"))
        {
            {
                Console.WriteLine(line);
            }
        }

        return Task.CompletedTask;
    }
}

public class ExportLostArchiveStoryMenuCommandArg
{
    public int CageMemoryId { get; init; }
}
