using System.Collections.Generic;
using ImGui.Forms.Controls;
using nier_rein_gui.Forms.Panels.SubQuests.Base;
using NierReincarnation;
using NierReincarnation.Core.Dark.Calculator;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.View.UserInterface;
using Veldrid;

namespace nier_rein_gui.Forms.Panels.Map
{
    class MapChapterPanel : ChapterPanel<MainQuestChapterData>
    {
        public MapChapterPanel(NierReinContexts rein, IList<MainQuestChapterData> chapters) : base(rein,chapters)
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

        protected override Panel GetQuestListPanel(NierReinContexts rein,MainQuestChapterData chapter)
        {
            return new MapGimmickListPanel(rein, chapter);
        }
    }
}
