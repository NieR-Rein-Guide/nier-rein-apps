using NierReincarnation.Core.Octo.Data;

namespace NierReincarnation.Datamine.Command;

public class ExportResourcesCommand : AbstractExportCommand
{
    public override string FileExt => string.Empty;

    public override string GetDownloadUrl(Item item) => DataManager.GenerateResourceUrl(item);

    public override IEnumerable<Item> GetAssets(BaseExportEntityCommandArg arg)
    {
        var items = DataManager.GetAllResourceNames()
            .Select(x => DataManager.GetResourceItemByName(x, arg.IncludeDeleted));

        return FilterItems(items, arg);
    }
}

public class ExportResourcesCommandArg : BaseExportEntityCommandArg
{
}
