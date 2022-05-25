using NierReincarnation.Core.Adam.Framework.Gameplay.Paradigm;
using NierReincarnation.Core.Dark.Variable;

namespace NierReincarnation.Core.Dark
{
    // Dark.FieldState
    static class FieldState
    {
        public static readonly string kBackground = "background"; // 0x0
        public static readonly string kCamer = "camera"; // 0x8
        public static readonly string kStory = "story"; // 0x10
        public static readonly string kChapter = "chapter"; // 0x18
        public static readonly string kEventMap = "eventmap"; // 0x20
        public static readonly string kGameTurnBattle = "gameturnbattle"; // 0x28
        public static readonly string kMap = "map"; // 0x30
        public static readonly string kQuest = "quest"; // 0x38
        public static readonly string kScene = "scene"; // 0x40
        public static readonly string kNetwork = "network"; // 0x48
        public static readonly string kUser = "user"; // 0x50
        public static readonly string kUserInterface = "user_interface"; // 0x58
        public static readonly string kResultState = "result_state"; // 0x60
        public static readonly string kMissionState = "mission_state"; // 0x68

        //public static StateBackground FieldStateBackground(this DataStructure data) { }

        //public static StateCamera FieldStateCamera(this DataStructure data) { }

        //public static StateStory FieldStateStory(this DataStructure data) { }

        //public static StateChapter FieldStateChapter(this DataStructure data) { }

        //public static StateEventMap FieldStateEventMap(this DataStructure data) { }

        //public static StateGameTurnBattle FieldStateGameTurnBattle(this DataStructure data) { }

        //public static StateQuest FieldStateQuest(this DataStructure data) { }

        //public static StateScene FieldStateScene(this DataStructure data) { }

        //public static StateNetwork FieldStateNetwork(this DataStructure data) { }

        public static StateUser FieldStateUser(this DataStructure data)
        {
            data.GetVariable<StateUser>(kBackground, out var result);
            return result;
        }

        //public static StateUserInterface FieldStateUserInterface(this DataStructure data) { }
    }
}
