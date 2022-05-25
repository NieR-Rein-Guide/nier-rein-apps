using System.Collections.Generic;
using ImGui.Forms.Controls;
using nier_rein_gui.Controls;
using NierReincarnation;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.View.UserInterface;

namespace nier_rein_gui.Forms.SubForms
{
    partial class MainQuestPanel : Panel
    {
        private readonly NierReinContexts _rein;

        private List<MainQuestSeasonData> _seasons;
        private List<MainQuestChapterData> _chapters;

        public MainQuestPanel(NierReinContexts rein)
        {
            _rein = rein;

            InitializeComponent();

            foreach(var seasonBtn in seasonButtonList)
                seasonBtn.Clicked += SeasonBtn_Clicked;
            foreach (var chapterBtn in chapterButtonList)
                chapterBtn.Clicked += ChapterBtn_Clicked;
        }

        private void SeasonBtn_Clicked(object sender, System.EventArgs e)
        {
            foreach (var seasonBtn in seasonButtonList)
                seasonBtn.Active = seasonBtn == sender;

            var btnIndex = seasonButtonList.IndexOf((NierButton) sender);
            SetChapterList(CreateChapterButtonList(btnIndex));

            foreach (var chapterBtn in chapterButtonList)
                chapterBtn.Clicked += ChapterBtn_Clicked;
        }

        private void ChapterBtn_Clicked(object sender, System.EventArgs e)
        {
            foreach (var chapterBtn in chapterButtonList)
                chapterBtn.Active = chapterBtn == sender;

            var btnIndex = chapterButtonList.IndexOf((NierButton)sender);
        }

        private List<MainQuestSeasonData> GetSeasons()
        {
            return _seasons = CalculatorQuest.GetMainQuestSeasons();
        }

        private List<MainQuestChapterData> GetChapters(int seasonIndex)
        {
            return _chapters = CalculatorQuest.GetMainQuestChapters(_seasons[seasonIndex].MainQuestSeasonId);
        }
    }
}
