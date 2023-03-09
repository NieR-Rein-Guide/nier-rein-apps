namespace NierReincarnation.Core.Octo
{
    class AssetLoader
    {
        public enum LoadPriority : byte
        {
            AssetBundle = 0,
            AssetBundleOnly = 1,
            Resources = 2,
            ResourcesOnly = 3
        }
    }
}
