using ImGui.Forms.Controls;
using nier_rein_gui.Controls;
using nier_rein_gui.Controls.Buttons;
using nier_rein_gui.Dialogs;
using NierReincarnation;
using NierReincarnation.Core.Dark.View.UserInterface;
using NierReincarnation.Core.Dark.View.UserInterface.Outgame;

namespace nier_rein_gui.Forms.SubForms
{
    partial class MainQuestPanel : Panel
    {
        private readonly NierReinContexts _rein;

        public MainQuestPanel(NierReinContexts rein)
        {
            _rein = rein;

            InitializeComponent();
        }

        private void SeasonBtn_Clicked(NierButton sender, MainQuestSeasonData season)
        {
            _currentSeason = season;

            foreach (var seasonBtn in seasonLayout.Items)
                (seasonBtn.Content as NierButton).Active = sender == seasonBtn.Content;

            UpdateChapters(season);
        }

        private void ChapterBtn_Clicked(NierButton sender, MainQuestChapterData chapter)
        {
            _currentChapter = chapter;

            foreach (var chapterBtn in chapterList.Items)
                (chapterBtn as NierButton).Active = chapterBtn == sender;

            var difficulties = chapter.MainQuestChapterDifficultyTypes;
            var difficulty = _currentDifficulty;

            if (!difficulties.Contains(_currentDifficulty))
                difficulty = difficulties[0];

            UpdateDifficulty(difficulty);
            UpdateQuests(chapter, difficulty);
        }

        private void DifficultyButton_Clicked1(object sender, System.EventArgs e)
        {
            var newDifficulty = _currentDifficulty + 1;
            if (!_currentChapter.MainQuestChapterDifficultyTypes.Contains(newDifficulty))
                newDifficulty = _currentChapter.MainQuestChapterDifficultyTypes[0];

            UpdateDifficulty(newDifficulty);
            UpdateQuests(_currentChapter, newDifficulty);
        }

        private async void QuestBtn_Clicked(NierQuestButton sender, QuestCellData quest)
        {
            var farmDlg = new MainQuestFarmDialog(_rein, _quests, quest);
            await farmDlg.ShowAsync();

            UpdateQuests(_currentChapter, _currentDifficulty);
        }
    }
}
