using NierReincarnation.Core.Dark.Component.Story;

namespace NierReincarnation.Core.Dark.View.UserInterface.Outgame
{
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
	}
}
