using ImGui.Forms.Controls;
using NierReincarnation.App.Forms.Panels.SubQuests.Base;
using NierReincarnation.Core.Dark.Calculator;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.View.UserInterface;
using System.Collections.Generic;

namespace NierReincarnation.App.Forms.Panels.Map
{
    internal class MapChapterPanel : ChapterPanel<MainQuestChapterData>
    {
        public MapChapterPanel(NierReinContexts rein, IList<MainQuestChapterData> chapters) : base(rein, chapters)
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
            return new MapGimmickListPanel(rein, chapter);
        }
    }
}
