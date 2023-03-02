using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.View.UserInterface.Outgame
{
    public class ChapterQuestData
    {
        public string ChapterNumberName { get; set; }
        public string ChapterTitle { get; set; }
        public int ChapterSortOrder { get; set; }
        public List<QuestCellData> QuestDataList { get; set; }
    }
}
