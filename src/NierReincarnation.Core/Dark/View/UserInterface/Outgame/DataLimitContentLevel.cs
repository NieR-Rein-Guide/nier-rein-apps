namespace NierReincarnation.Core.Dark.View.UserInterface.Outgame;

public class DataLimitContentLevel
{
    public int EventQuestChapterId { get; set; }

    public int SortOrder { get; set; }

    public int QuestCount { get; set; }

    public int QuestClearCount { get; set; }

    public DataPossessionItem LevelClearReward { get; set; }

    public string LevelName { get; set; }

    public bool IsLock { get; set; }

    public string LockText { get; set; }

    public bool IsClear { get; set; }

    public QuestFieldEffectData[] FieldEffects { get; set; }
}
