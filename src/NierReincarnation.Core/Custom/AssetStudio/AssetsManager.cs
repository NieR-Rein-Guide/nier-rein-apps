namespace NierReincarnation.Core.AssetStudio;

/// <summary>
/// Minimal implementation of AssetsManager that works with text assets
/// </summary>
public class AssetsManager
{
    public List<TextAsset> TextAssets = new();

    public void LoadFiles(params string[] files)
    {
        Load(files);
    }

    public void LoadFolder(string path)
    {
        var files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories).ToArray();
        Load(files);
    }

    private void Load(string[] files)
    {
        foreach (var file in files)
        {
            try
            {
                LoadFile(file);
            }
            catch (Exception) { }
        }
    }

    private void LoadFile(string fullName)
    {
        FileReader reader = new(fullName);
        LoadBundleFile(reader);
    }

    private void LoadAssetsFromMemory(FileReader fileReader)
    {
        SerializedFile assetsFile = new(fileReader);

        foreach (var objectInfo in assetsFile.Objects)
        {
            ObjectReader objectReader = new(fileReader, objectInfo);

            if (objectReader.Type != ClassIDType.TextAsset) continue;
            TextAssets.Add(new TextAsset(objectReader));
        }
    }

    private void LoadBundleFile(FileReader reader)
    {
        BundleFile bundleFile = new(reader);
        foreach (var fileStream in bundleFile.FileStreams)
        {
            FileReader subReader = new(fileStream);
            LoadAssetsFromMemory(subReader);
        }

        reader.Dispose();
    }

    public void Clear()
    {
        TextAssets.Clear();
    }
}
