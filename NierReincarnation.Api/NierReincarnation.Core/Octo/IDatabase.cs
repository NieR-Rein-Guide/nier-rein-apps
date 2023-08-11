namespace NierReincarnation.Core.Octo;

public interface IDatabase
{
    string[] GetAllAssetBundleNames();

    string[] GetAllResourceNames();
}
