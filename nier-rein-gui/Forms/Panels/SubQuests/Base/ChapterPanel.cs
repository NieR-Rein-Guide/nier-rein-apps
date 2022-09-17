using System.Collections.Generic;
using ImGui.Forms.Controls;
using NierReincarnation;

namespace nier_rein_gui.Forms.Panels.SubQuests.Base
{
    abstract partial class ChapterPanel<TChapterData> : Panel
    {
        private readonly NierReinContexts _rein;
        private readonly IList<TChapterData> _chapters;

        public ChapterPanel(NierReinContexts rein, IList<TChapterData> chapters)
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
