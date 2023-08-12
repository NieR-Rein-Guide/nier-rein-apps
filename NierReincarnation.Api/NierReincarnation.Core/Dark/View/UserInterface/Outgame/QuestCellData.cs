using NierReincarnation.Core.Dark.Component.Story;
using NierReincarnation.Core.Dark.Generated.Type;

namespace NierReincarnation.Core.Dark.View.UserInterface.Outgame;

public class QuestCellData
{
    public IQuest Quest { get; set; }

    public int QuestOrder { get; set; }

    public string QuestName { get; set; }

    public bool IsStoryQuest { get; set; }

    public bool IsLock { get; set; }

    public QuestMissionData[] Missions { get; set; }

    public string UnlockQuestText { get; set; }

    public string QuestLevelText { get; set; }

    // CUSTOM: Determines the scenes associated with the quest
    public List<EntityMQuestScene> Scenes { get; set; }

    // CUSTOM: Determines the scene id for the battle field
    public int FieldSceneId => Scenes.FirstOrDefault(x => x.QuestSceneType == QuestSceneType.FIELD)?.QuestSceneId ?? 0;

    // CUSTOM: Determines if quest was already cleared
    public bool IsClear { get; set; }

    // CUSTOM: Determines the difficulty this quest is assigned to
    public DifficultyType DifficultyType { get; set; }

    // CUSTOM: Determines the attribute of the quest
    public QuestDisplayAttributeType Attribute { get; set; }
}
