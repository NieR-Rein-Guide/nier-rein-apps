using NierReincarnation.Core.Adam.Framework.Resource;
using NierReincarnation.Core.Octo;
using NierReincarnation.Core.Octo.Data;
using NierReincarnation.Core.Octo.Util;
using NierReincarnation.Core.UnityEngine;
using System.ComponentModel;

namespace NierReincarnation.Api.Service;

public static class AssetService
{
    private static readonly Func<DataManager, IEnumerable<Item>> GetAssets = manager => manager.GetAllAssetBundleNames().Select(n => manager.GetAssetBundleItemByName(n));

    private static readonly Func<DataManager, IEnumerable<Item>> GetResources = manager => manager.GetAllResourceNames().Select(n => manager.GetResourceItemByName(n));

    private static readonly Func<Item, SystemLanguage, bool> TextAssets = (asset, lang) => asset.name.StartsWith(GetTextAssetPrefix(lang));

    private static readonly Func<Item, bool> SelectAll = _ => true;

    public static async Task DownloadAssetsAsync(Func<Item, bool>? itemSelector = null, bool skipExistingFiles = true) =>
        await DownloadFileSet(Path.Combine("v1", $"{DarkOctoSetupper.CreateSetting().AppId}", "assets"), true, GetAssets, itemSelector ?? SelectAll, skipExistingFiles);

    public static async Task DownloadResourcesAsync(Func<Item, bool>? itemSelector = null, bool skipExistingFiles = true) =>
        await DownloadFileSet("resources", false, GetResources, itemSelector ?? SelectAll, skipExistingFiles);

    public static int GetAssetSize(Func<Item, bool> itemSelector) => CalculateTotalSize(GetAssets, itemSelector);

    public static int GetResourceSize(Func<Item, bool> itemSelector) => CalculateTotalSize(GetResources, itemSelector);

    public static int GetAssetCount(Func<Item, bool> itemSelector) => GetAssetCount(GetAssets, itemSelector);

    public static int GetResourceCount(Func<Item, bool> itemSelector) => GetAssetCount(GetResources, itemSelector);

    public static async Task DownloadTextAssetsAsync(SystemLanguage language, bool skipExistingFiles = true) => await DownloadAssetsAsync(i => TextAssets(i, language));

    #region Internal

    private static async Task DownloadFileSet(string folder, bool isAssetBundle, Func<DataManager, IEnumerable<Item>> getItemsFunc,
        Func<Item, bool> itemSelector, bool skipExistingFiles = true)
    {
        // Ensure target folder
        string targetDir = Path.Combine(FileUtil.GetCachePath(), folder);

        // Setup instances
        HttpClient httpClient = new() { Timeout = Timeout.InfiniteTimeSpan };
        var dataManager = (DataManager)OctoManager.Database;

        var tasks = getItemsFunc(dataManager).Where(itemSelector).Select(x => ProcessSingleAsset(x, targetDir, isAssetBundle, httpClient, dataManager, skipExistingFiles));
        await Task.WhenAll(tasks);
    }

    private static async Task ProcessSingleAsset(Item item, string targetDir, bool isAssetBundle,
        HttpClient httpClient, DataManager dataManager, bool skipExistingFile = true)
    {
        string targetPath = Path.Combine(targetDir, item.name.Replace(')', '/'));
        if (isAssetBundle)
        {
            targetPath += ".asset";
        }

        // TODO: Use correct revision check to see if file is up-to-date
        if (skipExistingFile && File.Exists(targetPath))
        {
            //// Decrypt if file is asset bundle
            //if (!isAssetBundle) return;

            //// If existing file is still encrypted, decrypt it
            //var existingBuffer = await File.ReadAllBytesAsync(targetPath);

            //var existingDecBuffer = new byte[existingBuffer.Length];
            //DecryptInternal(existingBuffer, existingDecBuffer, item.name);

            //// If the decryption changed the content, write it back to the file
            //if (existingBuffer[0] != existingDecBuffer[0])
            //{
            //    await File.WriteAllBytesAsync(targetPath, existingDecBuffer);
            //}

            return;
        }

        // Download file
        var url = isAssetBundle ? dataManager.GenerateAssetBundleUrl(item) : dataManager.GenerateResourceUrl(item);
        var res = await httpClient.GetAsync(url);

        if (!res.IsSuccessStatusCode) return;

        // Decrypt file
        var content = await res.Content.ReadAsByteArrayAsync();
        if (isAssetBundle)
        {
            var outputBuffer = new byte[res.Content.Headers.ContentLength ?? 0];
            DecryptInternal(content, outputBuffer, item.name);

            content = outputBuffer;
        }

        // Write file
        Directory.CreateDirectory(Path.GetDirectoryName(targetPath));

        await using var output = File.Create(targetPath);
        output.Write(content);
    }

    private static string GetTextAssetPrefix(SystemLanguage language)
    {
        return language switch
        {
            SystemLanguage.English => "text)en",
            SystemLanguage.Japanese => "text)ja",
            _ => throw new InvalidEnumArgumentException(nameof(language)),
        };
    }

    private static int CalculateTotalSize(Func<DataManager, IEnumerable<Item>> getItemsFunc, Func<Item, bool> itemSelector)
    {
        var totalSize = 0;

        var dataManager = (DataManager)OctoManager.Database;

        foreach (var item in getItemsFunc(dataManager).Where(itemSelector).ToArray())
        {
            totalSize += item.size;
        }

        return totalSize;
    }

    private static int GetAssetCount(Func<DataManager, IEnumerable<Item>> getItemsFunc, Func<Item, bool> itemSelector)
    {
        var dataManager = (DataManager)OctoManager.Database;

        return getItemsFunc(dataManager).Count(itemSelector);
    }

    #region Decryption

    private static void DecryptInternal(byte[] buffer, byte[] output, string mask)
    {
        // Return if buffer is marked as raw
        if (buffer[0] != 0x31 && buffer[0] != 0x32)
        {
            Array.Copy(buffer, output, buffer.Length);
            return;
        }

        // Determine header length
        var headerLength = 256;
        if (buffer[0] == 0x32)
            headerLength = buffer.Length;

        // Create mask
        var maskLen = mask.Length << 1;
        var maskBuffer = new byte[maskLen];
        StringToMaskBytes(mask, maskBuffer);

        // Decrypt
        var i = 0;
        do
        {
            var k = i / maskLen;
            output[i] = (byte)(maskBuffer[i - (k * maskLen)] ^ buffer[i]);
            i++;
        } while (i < headerLength);

        if (headerLength != output.Length)
            Array.Copy(buffer, headerLength, output, headerLength, output.Length - headerLength);

        output[0] = 0x55;
    }

    private static void StringToMaskBytes(string mask, byte[] output)
    {
        if (string.IsNullOrEmpty(mask))
            return;

        // First pass
        var maskLen = mask.Length;
        int i = 0, j = 0, k = output.Length - 1;
        do
        {
            var c = mask[j];
            j++;
            output[i] = (byte)c;
            i += 2;
            output[k] = (byte)~c;
            k -= 2;
        } while (maskLen != j);

        // Second pass
        var byteLen = output.Length;
        int l = byteLen, a = 0;
        maskLen = 0xbb;
        j = l;

        do
        {
            j--;
            maskLen = (((maskLen & 1) << 7) | (maskLen >> 1)) ^ output[a];
            a++;
        } while (j != 0);

        var b = 0;
        do
        {
            l--;
            output[b] = (byte)(output[b] ^ (byte)maskLen);
            b++;
        } while (l != 0);
    }

    #endregion Decryption

    #endregion Internal
}
