using static NierReincarnation.Core.Octo.OctoManager;

namespace NierReincarnation.Datamine.Command;

public class ExportAssetsResourcesMenuCommand : AbstractMenuCommand
{
    public override bool IsActive => Program.AppSettings.IsSetup;

    public override bool Reset => true;

    public override bool Login => false;

    public override int Revision => Program.AppSettings.DbRevision;

    private static int DbRevision => Internal._dataManager.Revision;

    private readonly List<string> FoldersToExport = new() { "2d", "audio", "character_select", "minigame", "text", "timeline", "ui", "voice" };

    public override async Task ExecuteAsync()
    {
        if (DbRevision <= Revision)
        {
            Console.WriteLine($"Already up-to-date, at revision {DbRevision}");
            return;
        }

        Console.WriteLine($"Updating assets {Revision} -> {DbRevision}");

        // Execute command - Assets
        await new ExportAssetsCommand().ExecuteAsync(new AssetExportCommandArg
        {
            DownloadPath = Constants.AssetsRawPath,
            ExportAssets = true,
            FoldersToExport = FoldersToExport
        });

        Console.WriteLine();

        Console.WriteLine($"Updating resources {Revision} -> {DbRevision}");

        // Execute command - Resources
        await new ExportResourcesCommand().ExecuteAsync(new ExportResourcesCommandArg
        {
            DownloadPath = Constants.ResourcesPath,
            Filters = new List<EntityExportFilter>
                {
                    new EntityExportFilter
                    {
                        FilterType = EntityExportFilterType.IsExactly,
                        FilterText = "tag.txt",
                        IsMatch = false
                    }
                }
        });

        Program.AppSettings.DbRevision = DbRevision;
        await new SaveConfigurationCommand().ExecuteAsync();
    }
}
