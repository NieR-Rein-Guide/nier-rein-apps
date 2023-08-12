using NierReincarnation.Core.Adam.Framework.Gameplay.Paradigm;
using NierReincarnation.Core.Dark.Variable;

namespace NierReincarnation.Core.Dark;

// Dark.FieldState
internal static class FieldState
{
    public static readonly string kBackground = "background";
    public static readonly string kCamer = "camera";
    public static readonly string kStory = "story";
    public static readonly string kChapter = "chapter";
    public static readonly string kEventMap = "eventmap";
    public static readonly string kGameTurnBattle = "gameturnbattle";
    public static readonly string kMap = "map";
    public static readonly string kQuest = "quest";
    public static readonly string kScene = "scene";
    public static readonly string kNetwork = "network";
    public static readonly string kUser = "user";
    public static readonly string kUserInterface = "user_interface";
    public static readonly string kResultState = "result_state";
    public static readonly string kMissionState = "mission_state";

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
