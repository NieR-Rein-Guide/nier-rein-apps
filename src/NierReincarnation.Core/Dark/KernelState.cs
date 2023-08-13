using NierReincarnation.Core.Adam.Framework.Gameplay.Paradigm;
using NierReincarnation.Core.Dark.Networking;

namespace NierReincarnation.Core.Dark;

public static class KernelState
{
    public static NetworkConfig NetworkConfig { get; set; }

    private const string kUserStatePath = "userstate";

    private static DataStructure _userState;

    public static bool GetUserState(out DataStructure data)
    {
        if (_userState == null)
            GetDataStructure(kUserStatePath, out _userState);

        data = _userState;
        return _userState != null;
    }

    private static bool GetDataStructure(string path, out DataStructure data)
    {
        // data = UnityEngine.GameObject.Find(path)?.GetComponent<DataStructure>();
        data = new DataStructure();

        return data != null;
    }
}
