using AssetStudio;
using Object = AssetStudio.Object;

namespace NierReincarnation.Datamine.Extension;

public static class AssetExtensions
{
    public static string GetItemName(this Object item)
    {
        return item switch
        {
            AudioClip audioClip => audioClip.m_Name,
            Sprite sprite => sprite.m_Name,
            TextAsset textAsset => textAsset.m_Name,
            AssetBundle assetBundle => assetBundle.m_Name,

            _ => string.Empty
        };
    }
}
