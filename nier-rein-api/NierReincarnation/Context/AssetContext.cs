using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using NierReincarnation.Core.Adam.Framework.Resource;
using NierReincarnation.Core.Octo;
using NierReincarnation.Core.Octo.Data;
using NierReincarnation.Core.Octo.Util;
using NierReincarnation.Core.UnityEngine;

namespace NierReincarnation.Context
{
    public class AssetContext
    {
        private static object _lockObj = new object();

        private static readonly Func<DataManager, IEnumerable<Item>> GetAssets = manager =>
            manager.GetAllAssetBundleNames().Select(n => manager.GetAssetBundleItemByName(n));
        private static readonly Func<DataManager, IEnumerable<Item>> GetResources = manager =>
            manager.GetAllResourceNames().Select(n => manager.GetResourceItemByName(n));

        private static readonly Func<Item, bool> SelectAll = i => true;
        private static readonly Func<Item, Language, bool> Texts = (i, l) => i.name.StartsWith(GetLanguagePath(l));

        public async Task DownloadAllAssets()
        {
            await DownloadAssets(null);
        }

        public async Task DownloadAllResources()
        {
            await DownloadResources(null);
        }

        public int GetTextAssetSize(Language language)
        {
            return GetAssetSize(i => Texts(i, language));
        }

        public int GetTextAssetCount(Language language)
        {
            return GetAssetCount(i => Texts(i, language));
        }

        public async Task DownloadTextAssets(Language language)
        {
            await DownloadAssets(i => Texts(i, language));
        }

        public async Task DownloadAssets(Func<Item, bool> itemSelector)
        {
            itemSelector ??= SelectAll;

            await DownloadFileSet(Path.Combine("v1", $"{DarkOctoSetupper.CreateSetting().AppId}", "assets"), true, GetAssets, itemSelector);
        }

        public async Task DownloadResources(Func<Item, bool> itemSelector)
        {
            itemSelector ??= SelectAll;

            await DownloadFileSet("resources", false, GetResources, itemSelector);
        }

        // TODO: Make more generic
        public void RemoveAsset(string name)
        {
            var path = Path.Combine(FileUtil.GetCachePath(), "v1", $"{DarkOctoSetupper.CreateSetting().AppId}", "assets", name);
            if (File.Exists(path))
                File.Delete(path);
        }

        public int GetAssetSize(Func<Item, bool> itemSelector)
        {
            return CalculateTotalSize(GetAssets, itemSelector);
        }

        public int GetAssetCount(Func<Item, bool> itemSelector)
        {
            return GetAssetCount(GetAssets, itemSelector);
        }

        private static int CalculateTotalSize(Func<DataManager, IEnumerable<Item>> getItemsFunc, Func<Item, bool> itemSelector)
        {
            var result = 0;

            var dataManager = (DataManager)OctoManager.Database;

            var items = getItemsFunc(dataManager).Where(itemSelector).ToArray();
            foreach (var item in items)
                result += item.size;

            return result;
        }

        private static int GetAssetCount(Func<DataManager, IEnumerable<Item>> getItemsFunc, Func<Item, bool> itemSelector)
        {
            var dataManager = (DataManager)OctoManager.Database;

            return getItemsFunc(dataManager).Where(itemSelector).Count();
        }

        private static async Task DownloadFileSet(string folder, bool isAssetBundle, Func<DataManager, IEnumerable<Item>> getItemsFunc, Func<Item, bool> itemSelector)
        {
            // Ensure target folder
            var targetDir = Path.Combine(FileUtil.GetCachePath(), folder);

            // Setup instances
            var client = new HttpClient { Timeout = Timeout.InfiniteTimeSpan };
            var dataManager = (DataManager)OctoManager.Database;

            var items = getItemsFunc(dataManager).Where(itemSelector).ToArray();

            var counter = 0;
            Console.Write($"\rProcessed 0/{items.Length}");

            items.AsParallel().ForAll(item =>
            {
                ProcessSingleAsset(item, targetDir, isAssetBundle, client, dataManager);

                lock (_lockObj)
                {
                    counter++;
                    Console.Write($"\rProcessed {counter + 1}/{items.Length}");
                }
            });

            Console.WriteLine();
        }

        private static void ProcessSingleAsset(Item item, string targetDir, bool isAssetBundle, HttpClient client, DataManager dataManager)
        {
            var targetPath = Path.Combine(targetDir, item.name.Replace(')', '/'));
            if (isAssetBundle)
                targetPath += ".asset";

            // TODO: Use correct revision check to see if file is up-to-date
            if (File.Exists(targetPath))
            {
                // Decrypt if file is asset bundle
                if (!isAssetBundle)
                    return;

                // If existing file is still encrypted, decrypt it
                var existingBuffer = File.ReadAllBytes(targetPath);

                var existingDecBuffer = new byte[existingBuffer.Length];
                DecryptInternal(existingBuffer, existingDecBuffer, item.name);

                // If the decryption changed the content, write it back to the file
                if (existingBuffer[0] != existingDecBuffer[0])
                    File.WriteAllBytes(targetPath, existingDecBuffer);

                return;
            }

            // Download file
            var url = isAssetBundle ? dataManager.GenerateAssetBundleUrl(item) : dataManager.GenerateResourceUrl(item);

            var req = new HttpRequestMessage(HttpMethod.Get, url);
            var res = client.Send(req);

            // Decrypt file
            var content = res.Content.ReadAsByteArrayAsync().Result;
            if (isAssetBundle)
            {
                var outputBuffer = new byte[res.Content.Headers.ContentLength ?? 0];
                DecryptInternal(content, outputBuffer, item.name);

                content = outputBuffer;
            }

            // Write file
            EnsureDirectory(Path.GetDirectoryName(targetPath));

            using var output = File.Create(targetPath);
            output.Write(content);
        }

        private static void EnsureDirectory(string dir)
        {
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
        }

        private static string GetLanguagePath(Language language)
        {
            switch (language)
            {
                case Language.English:
                    return "text)en";

                case Language.Japanese:
                    return "text)jp";

                default:
                    throw new InvalidEnumArgumentException(nameof(language));
            }
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
                output[i] = (byte)(maskBuffer[i - k * maskLen] ^ buffer[i]);
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

        #endregion
    }
}
