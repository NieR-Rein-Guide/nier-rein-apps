using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.View.UserInterface.Outgame
{
    public sealed class DataLabyrinthQuestListStage
    {
        public int StageSortOrder { get; }
        public string StageName { get; }
        public IReadOnlyList<DataLabyrinthQuestListQuest> QuestListQuests { get; }

        public DataLabyrinthQuestListStage(int stageSortOrder, string stageName, IReadOnlyList<DataLabyrinthQuestListQuest> questListQuests)
        {
            StageSortOrder=stageSortOrder;
            StageName = stageName;
            QuestListQuests = questListQuests;
        }
    }
}
