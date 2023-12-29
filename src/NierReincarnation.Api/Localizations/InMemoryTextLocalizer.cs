using NierReincarnation.Api.Service;
using NierReincarnation.Core.Octo.Data;
using NierReincarnation.Core.Octo;
using NierReincarnation.Core.UnityEngine;
using NierReincarnation.Core.AssetStudio;
using System.Collections.Concurrent;

namespace NierReincarnation.Api.Localizations;

public class InMemoryTextLocalizer(DataManager? dataManager = null, List<Item>? items = null, int batchSize = 2048) : BaseTextLocalizer
{
    public override async Task<Dictionary<string, string>> CreateAsync(SystemLanguage lang = SystemLanguage.English)
    {
        Dictionary<string, string> result = [];

        // Download assets in memory
        var byteList = await DownloadAssetsAsync(lang);

        // Process assets
        return ProcessAssets(LoadAssets(byteList));
    }

    private async Task<List<byte[]>> DownloadAssetsAsync(SystemLanguage lang)
    {
        ConcurrentBag<byte[]> byteList = [];
        dataManager ??= (DataManager)OctoManager.Database;
        using HttpClient httpClient = new() { Timeout = Timeout.InfiniteTimeSpan };

        var tasks = (items ?? AssetService.GetAssets(dataManager))
            .Where(x => AssetService.IsTextAsset(x, lang))
            .Select(DownloadAssetAsync)
            .ToList();

        for (int i = 0; i < tasks.Count; i+= batchSize)
        {
            List<Task> currentBatch = tasks.Skip(i).Take(batchSize).ToList();

            await Task.WhenAll(currentBatch);
            await Task.Delay(100);
        }

        async Task DownloadAssetAsync(Item textAsset)
        {
            byteList.Add(await AssetService.DownloadAssetAsync(textAsset, true, httpClient, dataManager));
        }

        return [.. byteList];
    }

    private static List<TextAsset> LoadAssets(List<byte[]> byteList)
    {
        AssetsManager assetManager = new();

        foreach (var bytes in byteList)
        {
            using MemoryStream memoryStream = new(bytes);
            FileReader fileReader = new(memoryStream);
            assetManager.LoadBundleFile(fileReader);
        }

        return assetManager.TextAssets;
    }
}
