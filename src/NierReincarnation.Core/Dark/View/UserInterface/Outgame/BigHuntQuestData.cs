using NierReincarnation.Core.Dark.Component.Story;

namespace NierReincarnation.Core.Dark.View.UserInterface.Outgame;

public class BigHuntQuestData
{
    public int BigHuntBossQuestId { get; set; }

    public IQuest Quest { get; set; }

    public bool IsClearQuest { get; set; }

    public QuestDisplayAttributeType AttributeType { get; set; }

    public string QuestName { get; set; }

    public int RecommendPower { get; set; }

    public bool IsLock { get; set; }

    public string LockText { get; set; }

    public int DifficultyBonusPermilValue { get; set; }

    // CUSTOM
    public int SortOrder { get; set; }
}
