namespace NierReincarnation.Core.Dark.View.UserInterface.Outgame;

public class DataLabyrinthQuestList
{
    public string ChapterName { get; }

    public IReadOnlyList<DataLabyrinthQuestListStage> QuestListStages { get; }

    public DataLabyrinthQuestList(string chapterName, IReadOnlyList<DataLabyrinthQuestListStage> questListStages)
    {
        ChapterName = chapterName;
        QuestListStages = questListStages;
    }
}
