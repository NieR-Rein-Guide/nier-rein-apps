using DustInTheWind.ConsoleTools.Controls.Spinners;
using NierReincarnation.Core.Octo;
using NierReincarnation.Core.Octo.Data;
using NierReincarnation.Core.Octo.Proto;
using System.Text.RegularExpressions;

namespace NierReincarnation.Datamine.Command;

public abstract class AbstractExportCommand : IAsyncCommand<BaseExportEntityCommandArg>
{
    private static readonly object _lockObj = new();

    protected static DataManager DataManager => OctoManager.DataManager;

    public abstract string FileExt { get; }

    public abstract IEnumerable<Item> GetAssets(BaseExportEntityCommandArg arg);

    public abstract string GetDownloadUrl(Item item);

    protected virtual async Task<byte[]> GetResponseBytesAsync(HttpResponseMessage response, Item item)
    {
        return await response.Content.ReadAsByteArrayAsync();
    }

    public virtual async Task ExecuteAsync(BaseExportEntityCommandArg arg)
    {
        // Get assets to download
        IEnumerable<Item> items = GetAssets(arg);

        if (!items.Any()) return;

        // Download assets
        List<string> fileList = await DownloadAssetsAsync(arg, items);

        // Export assets
        if (arg.ExportAssets)
        {
            await ExportAssetsAsync(arg);
        }

        // Create changelog
        await CreateChangeLogAsync(fileList, arg.DownloadPath);
    }

    private async Task<List<string>> DownloadAssetsAsync(BaseExportEntityCommandArg arg, IEnumerable<Item> items)
    {
        ProgressBar progressBar = new() { MaxValue = items.Count(), UnitOfMeasurement = string.Empty, LabelText = "Downloading" };
        progressBar.Display();

        List<string> fileList = [];
        List<string> errors = [];

        var tasks = items.Select(x =>
        {
            string itemName = x.name.Replace(")", "\\") + FileExt;

            // Track item
            fileList.Add(itemName);

            // Download item
            return DownloadItem(x, itemName);
        });

        await Task.WhenAll(tasks);

        LogErrors(errors);

        progressBar.Close();

        return fileList;

        async Task DownloadItem(Item item, string itemName)
        {
            // Process added or updated items only
            if (item.state == Data.DataState.Add || item.state == Data.DataState.Update)
            {
                string tempFilePath = Path.Combine(arg.DownloadPath, Constants.TempFolder, $"{DataManager.Revision}", itemName);

                // Skip existing file
                if (File.Exists(tempFilePath)) return;

                // Download item
                HttpClient client = new()
                {
                    Timeout = Program.AppSettings.Timeout
                };

                HttpResponseMessage response;
                try
                {
                    response = await client.GetAsync(GetDownloadUrl(item));
                }
                catch (Exception)
                {
                    errors.Add(itemName);
                    return;
                }

                byte[] responseBytes = await GetResponseBytesAsync(response, item);

                // Write item to disk
                Directory.CreateDirectory(Path.GetDirectoryName(tempFilePath));
                await File.WriteAllBytesAsync(tempFilePath, responseBytes);

                lock (_lockObj)
                {
                    progressBar.Value++;
                }
            }
        }
    }

    private static void LogErrors(List<string> errors)
    {
        if (errors.Count > 0) Console.WriteLine();

        foreach (string error in errors)
        {
            Console.WriteLine($"Failed to download asset: {error}");
        }
    }

    protected virtual IEnumerable<Item> FilterItems(IEnumerable<Item> items, BaseExportEntityCommandArg arg)
    {
        if (arg.Filters == null) return items;

        foreach (var filter in arg.Filters)
        {
            items = filter.FilterType switch
            {
                EntityExportFilterType.StartsWith => items.Where(x => x.name.StartsWith(filter.FilterText) == filter.IsMatch),
                EntityExportFilterType.EndsWith => items.Where(x => x.name.EndsWith(filter.FilterText) == filter.IsMatch),
                EntityExportFilterType.Includes => items.Where(x => x.name.Contains(filter.FilterText) == filter.IsMatch),
                EntityExportFilterType.IsExactly => items.Where(x => x.name.Equals(filter.FilterText) == filter.IsMatch),
                EntityExportFilterType.Regex => items.Where(x => new Regex(filter.FilterText).IsMatch(x.name) == filter.IsMatch),
                _ => items
            };
        }

        return items;
    }

    protected virtual Task ExportAssetsAsync(BaseExportEntityCommandArg arg) => Task.CompletedTask;

    protected virtual async Task CreateChangeLogAsync(List<string> fileList, string downloadPath)
    {
        string filePath = Path.Combine(downloadPath, Constants.ChangelogFolder, $"{DataManager.Revision}.txt");
        Directory.CreateDirectory(Path.GetDirectoryName(filePath));

        await using StreamWriter output = File.CreateText(filePath);

        foreach (string file in fileList.OrderBy(x => x))
        {
            await output.WriteLineAsync(file);
        }
    }
}

public abstract class BaseExportEntityCommandArg
{
    public bool IncludeDeleted { get; init; }

    public string DownloadPath { get; init; }

    public List<EntityExportFilter> Filters { get; init; }

    public bool ExportAssets { get; init; }

    public string ExportPath { get; init; }

    public List<string> FoldersToExport { get; init; }
}

public sealed class EntityExportFilter
{
    public EntityExportFilterType? FilterType { get; init; }

    public string FilterText { get; init; }

    public bool IsMatch { get; init; } = true;
}

public enum EntityExportFilterType
{
    StartsWith,
    EndsWith,
    Includes,
    IsExactly,
    Regex
}
