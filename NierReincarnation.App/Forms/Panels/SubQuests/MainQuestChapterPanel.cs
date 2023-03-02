using ImGui.Forms.Controls;
using NierReincarnation.App.Forms.Panels.SubQuests.Base;
using NierReincarnation.App.Forms.Panels.SubQuests.Quests;
using NierReincarnation.Core.Dark.Calculator;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.View.UserInterface;
using System.Collections.Generic;

namespace NierReincarnation.App.Forms.Panels.SubQuests
{
    internal class MainQuestChapterPanel : ChapterPanel<MainQuestChapterData>
    {
        public MainQuestChapterPanel(NierReinContexts rein, IList<MainQuestChapterData> chapters) : base(rein, chapters)
        {
        }

        protected override string GetChapterName(MainQuestChapterData chapter)
        {
            return chapter.MainQuestChapterNumberName;
        }

        protected override bool IsUnlocked(MainQuestChapterData chapter)
        {
            return CalculatorQuest.IsUnlockMainQuestChapter(CalculatorStateUser.GetUserId(), chapter.MainQuestChapterId);
        }

        protected override Panel GetQuestListPanel(NierReinContexts rein, MainQuestChapterData chapter)
        {
            return new MainQuestListPanel(rein, chapter);
        }
    }
}
