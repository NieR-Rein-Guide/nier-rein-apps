using NierReincarnation.Core.Adam.Framework.Gameplay.Paradigm;
using NierReincarnation.Core.Dark.Networking;

namespace NierReincarnation.Core.Dark
{
    // Dark.KernelState
    static class KernelState
    {
        // 0x08
        public static NetworkConfig NetworkConfig { get; set; }
        // 0x10
        private static readonly string kUserStatePath = "userstate";
        // 0x48
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
}
