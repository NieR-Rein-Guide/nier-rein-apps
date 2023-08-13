using ImGui.Forms.Controls;
using System.Collections.Generic;

namespace NierReincarnation.App.Forms.Panels.SubQuests.Base
{
    internal abstract partial class ChapterPanel<TChapterData> : Panel
    {
        private readonly NierReinContexts _rein;
        private readonly IList<TChapterData> _chapters;

        protected ChapterPanel(NierReinContexts rein, IList<TChapterData> chapters)
        {
            _rein = rein;
            _chapters = chapters;

            InitializeComponent();

            UpdateChapterList(chapters);
            UpdateQuestList(rein, CurrentChapter);
        }

        protected abstract string GetChapterName(TChapterData chapter);

        protected abstract bool IsUnlocked(TChapterData chapter);

        protected abstract Panel GetQuestListPanel(NierReinContexts rein, TChapterData chapter);
    }
}
