using AssetStudio;
using DustInTheWind.ConsoleTools.Controls.Spinners;
using MoreLinq;
using NierReincarnation.Core.Octo.Data;
using NierReincarnation.Datamine.Extension;
using Object = AssetStudio.Object;

namespace NierReincarnation.Datamine.Command;

public class ExportAssetsCommand : AbstractExportCommand
{
    public override string FileExt => ".asset";

    private List<string> ExportedFiles { get; } = new();

    public override string GetDownloadUrl(Item item) => DataManager.GenerateAssetBundleUrl(item);

    public override IEnumerable<Item> GetAssets(BaseExportEntityCommandArg arg)
    {
        var items = DataManager.GetAllAssetBundleNames()
            .Select(x => DataManager.GetAssetBundleItemByName(x, arg.IncludeDeleted));

        return FilterItems(items, arg);
    }

    protected override async Task<byte[]> GetResponseBytesAsync(HttpResponseMessage response, Item item)
    {
        byte[] bytes = await response.Content.ReadAsByteArrayAsync();
        byte[] outputBuffer = new byte[response.Content.Headers.ContentLength ?? 0];
        DecryptInternal(bytes, outputBuffer, item.name);

        return outputBuffer;
    }

    protected override async Task ExportAssetsAsync(BaseExportEntityCommandArg arg)
    {
        ExportedFiles.Clear();
        var assetsDic = GetAssetsToExport(arg);
        List<string> errors = new();

        ProgressBar progressBar = new() { MaxValue = assetsDic.Count, UnitOfMeasurement = string.Empty, LabelText = "Exporting" };
        progressBar.Display();

        // Export assets
        string basePath = Path.Combine(Constants.AssetsLatestPath, $"{DataManager.Revision}");
        foreach ((Object asset, string container) in assetsDic)
        {
            string containerPath = !string.IsNullOrEmpty(container) ? Path.GetDirectoryName(container.Replace("assets/workspace/", string.Empty)) : "unsorted";

            try
            {
                ExportAsset(asset, basePath, containerPath);
            }
            catch (Exception)
            {
                errors.Add(Path.Combine(containerPath, FixFileName(asset.GetItemName()) + GetAssetExtension(asset)));
            }
            progressBar.Value++;
        }

        progressBar.Close();

        // Copy to main assets folder and create changelog
        if (ExportedFiles.Count > 0)
        {
            if (Program.AppSettings.AutoCopyAssets)
            {
                CopyAssets(basePath);
            }
            await CreateChangeLogAsync(ExportedFiles, Constants.AssetsPath);
        }

        // Log errors
        LogErrors(errors);
    }

    private static void LogErrors(List<string> errors)
    {
        if (errors.Count > 0) Console.WriteLine();

        foreach (string error in errors)
        {
            Console.WriteLine($"Failed to export asset: {error}");
        }
    }

    private static void CopyAssets(string sourcePath)
    {
        var filesToCopy = Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories);

        ProgressBar progressBar = new() { MaxValue = filesToCopy.Length, UnitOfMeasurement = string.Empty, LabelText = "Copying" };
        progressBar.Display();

        //Now Create all of the directories
        foreach (string dirPath in Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories))
        {
            Directory.CreateDirectory(dirPath.Replace(sourcePath, Constants.AssetsPath));
        }

        //Copy all the files & Replaces any files with the same name
        foreach (string newPath in Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories))
        {
            File.Copy(newPath, newPath.Replace(sourcePath, Constants.AssetsPath), true);
            progressBar.Value++;
        }

        progressBar.Close();
    }

    private static Dictionary<Object, string> GetAssetsToExport(BaseExportEntityCommandArg arg)
    {
        Dictionary<Object, string> assetsDic = new();
        List<(PPtr<Object>, string)> containers = new();
        List<Object> assetFileList = new();
        List<string> assetNames = new();

        // Load assets
        foreach (var folderToExport in arg.FoldersToExport)
        {
            var folderPath = Path.Combine(arg.DownloadPath, Constants.TempFolder, $"{DataManager.Revision}", folderToExport);

            if (!Directory.Exists(folderPath)) continue;

            AssetsManager assetsManager = new();
            assetsManager.LoadFolder(folderPath);
            assetFileList.AddRange(assetsManager.assetsFileList.SelectMany(x => x.Objects).Where(x => x is AudioClip || x is Sprite || x is TextAsset || x is AssetBundle));
        }

        // Collect assets and containers to export
        foreach (var asset in assetFileList)
        {
            // Skip duplicate assets
            string assetName = asset.GetItemName();
            if (assetNames.Contains(assetName)) continue;
            assetNames.Add(assetName);

            if (asset is AudioClip audioClip)
            {
                assetsDic.TryAdd(audioClip, string.Empty);
            }
            else if (asset is Sprite sprite)
            {
                assetsDic.TryAdd(sprite, string.Empty);
            }
            else if (asset is TextAsset textAsset)
            {
                assetsDic.TryAdd(textAsset, string.Empty);
            }
            else if (asset is AssetBundle assetBundle)
            {
                foreach (var m_Container in assetBundle.m_Container)
                {
                    int preloadIndex = m_Container.Value.preloadIndex;
                    int preloadSize = m_Container.Value.preloadSize;
                    int preloadEnd = preloadIndex + preloadSize;
                    for (int k = preloadIndex; k < preloadEnd; k++)
                    {
                        containers.Add((assetBundle.m_PreloadTable[k], m_Container.Key));
                    }
                }
            }
        }

        // Assign containers to assets
        foreach ((var pptr, string container) in containers)
        {
            if (pptr.TryGet(out Object obj))
            {
                if (obj is AudioClip || obj is Sprite || obj is TextAsset)
                {
                    assetsDic[obj] = container;
                }
            }
        }

        return assetsDic;
    }

    private static string GetAssetExtension(Object asset)
    {
        return asset switch
        {
            AudioClip => ".wav",
            Sprite => $".{nameof(ImageFormat.Png).ToLower()}",
            TextAsset => ".txt",
            _ => ".unknown"
        };
    }

    private bool ExportAsset(Object asset, string basePath, string containerPath)
    {
        return asset switch
        {
            AudioClip audioClip => ExportAudioClip(audioClip, basePath, containerPath),
            Sprite sprite => ExportSprite(sprite, basePath, containerPath),
            TextAsset textAsset => ExportTextAsset(textAsset, basePath, containerPath),
            _ => false
        };
    }

    public bool ExportAudioClip(AudioClip item, string basePath, string containerPath)
    {
        byte[] audioData = item.m_AudioData.GetData();
        if (audioData == null || audioData.Length == 0) return false;

        AudioClipConverter converter = new(item);
        string fileName = FixFileName(item.GetItemName()) + GetAssetExtension(item);

        if (!TryExportFile(basePath, containerPath, fileName, out string exportFullPath)) return false;

        byte[] buffer = converter.ConvertToWav();
        if (buffer == null) return false;

        File.WriteAllBytes(exportFullPath, buffer);
        ExportedFiles.Add(Path.Combine(containerPath, fileName));

        return true;
    }

    public bool ExportSprite(Sprite item, string basePath, string containerPath)
    {
        string fileName = FixFileName(item.GetItemName()) + GetAssetExtension(item);

        if (!TryExportFile(basePath, containerPath, fileName, out string exportFullPath)) return false;

        var image = item.GetImage();
        if (image != null)
        {
            using (image)
            {
                using (var file = File.OpenWrite(exportFullPath))
                {
                    image.WriteToStream(file, ImageFormat.Png);
                }
                ExportedFiles.Add(Path.Combine(containerPath, fileName));
                return true;
            }
        }
        return false;
    }

    public bool ExportTextAsset(TextAsset item, string basePath, string containerPath)
    {
        string fileName = FixFileName(item.GetItemName()) + GetAssetExtension(item);

        if (!TryExportFile(basePath, containerPath, fileName, out string exportFullPath)) return false;

        File.WriteAllBytes(exportFullPath, item.m_Script);
        ExportedFiles.Add(Path.Combine(containerPath, fileName));

        return true;
    }

    private static bool TryExportFile(string basePath, string containerPath, string fileName, out string fullPath)
    {
        fullPath = Path.Combine(basePath, containerPath, fileName);
        if (!File.Exists(fullPath))
        {
            Directory.CreateDirectory(Path.Combine(basePath, containerPath));
            return true;
        }
        return false;
    }

    private static string FixFileName(string str)
    {
        if (str.Length >= 260) return Path.GetRandomFileName();
        return Path.GetInvalidFileNameChars().Aggregate(str, (current, c) => current.Replace(c, '_'));
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
}

public class AssetExportCommandArg : BaseExportEntityCommandArg
{
}
