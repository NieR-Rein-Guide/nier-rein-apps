using NierReincarnation.Core.Art.Framework.ApiNetwork.Data;

namespace NierReincarnation.Core.Art.Framework.ApiNetwork.Parameter;

public class MasterDataVersionParameter
{
    public string MasterDataHash { get; set; }

    public MasterDataVersionParameter()
    {
        MasterDataHash = ApiSystem.Instance.DataStore.Get(Key.MasterDataHash);
    }

    public void UpdateMasterDataHash(string hash)
    {
        MasterDataHash = hash;
        ApiSystem.Instance.DataStore.Set(Key.MasterDataHash, hash);
    }
}
