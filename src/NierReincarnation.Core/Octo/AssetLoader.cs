namespace NierReincarnation.Core.Octo;

public class AssetLoader
{
    public enum LoadPriority
    {
        AssetBundle = 0,
        AssetBundleOnly = 1,
        Resources = 2,
        ResourcesOnly = 3
    }

    public enum LoadState
    {
        BeforeLoad = 0,
        Loading = 1,
        Loaded = 2,
        Fail = 3,
        Cancel = 4
    }
}
