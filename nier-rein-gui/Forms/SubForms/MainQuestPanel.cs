using System.Collections.Generic;
using ImGui.Forms.Controls;
using nier_rein_gui.Controls;
using nier_rein_gui.Dialogs;
using NierReincarnation;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.View.UserInterface;
using NierReincarnation.Core.Dark.View.UserInterface.Outgame;

namespace nier_rein_gui.Forms.SubForms
{
    partial class MainQuestPanel : Panel
    {
        private readonly NierReinContexts _rein;

        private List<MainQuestSeasonData> _seasons;
        private List<MainQuestChapterData> _chapters;
        private List<QuestCellData> _quests;
        private List<DifficultyType> _difficulties;

        private MainQuestSeasonData _currentSeason;
        private MainQuestChapterData _currentChapter;
        private DifficultyType _currentDifficulty = DefaultDifficulty;

        public MainQuestPanel(NierReinContexts rein)
        {
            _rein = rein;

            InitializeComponent();

            _currentSeason = _seasons[0];
            _currentChapter = _chapters[0];

            foreach (var seasonBtn in seasonButtonList)
                seasonBtn.Clicked += SeasonBtn_Clicked;
            foreach (var chapterBtn in chapterButtonList)
                chapterBtn.Clicked += ChapterBtn_Clicked;
            foreach (var questBtn in questButtonList)
                questBtn.Clicked += QuestBtn_Clicked;

            difficultyButton.Clicked += DifficultyButton_Clicked;
        }

        private void SeasonBtn_Clicked(object sender, System.EventArgs e)
        {
            foreach (var seasonBtn in seasonButtonList)
                seasonBtn.Active = seasonBtn == sender;

            var index = seasonButtonList.IndexOf((NierButton)sender);
            if (_seasons.Count < index || _seasons[index] == _currentSeason)
                return;

            UpdateChapters(index);
            UpdateQuests(0);

            _currentSeason = _seasons[index];
            _currentChapter = _chapters[0];

            UpdateCurrentDifficulty();
        }

        private void ChapterBtn_Clicked(object sender, System.EventArgs e)
        {
            foreach (var chapterBtn in chapterButtonList)
                chapterBtn.Active = chapterBtn == sender;

            var index = chapterButtonList.IndexOf((NierButton)sender);
            if (_chapters.Count < index || _chapters[index] == _currentChapter)
                return;

            UpdateQuests(index);

            _currentChapter = _chapters[index];

            UpdateCurrentDifficulty();
        }

        private async void QuestBtn_Clicked(object sender, System.EventArgs e)
        {
            var index = questButtonList.IndexOf((NierQuestButton)sender);
            if (index < 0 || _quests.Count <= index)
                return;

            var farmDlg = new MainQuestFarmDialog(_rein, _quests[index]);
            await farmDlg.ShowAsync();

            var seasonIndex = _seasons.IndexOf(_currentSeason);
            var chapterIndex = _chapters.IndexOf(_currentChapter);

            UpdateChapters(seasonIndex);
            UpdateQuests(chapterIndex);

            chapterButtonList[chapterIndex].Active = true;
        }

        private void DifficultyButton_Clicked(object sender, System.EventArgs e)
        {
            UpdateCurrentDifficulty(_currentDifficulty + 1);

            var index = _chapters.IndexOf(_currentChapter);
            UpdateQuests(index);
        }

        private List<MainQuestSeasonData> GetSeasons()
        {
            var seasonIndex = -1;
            if (_currentSeason != null)
                seasonIndex = _seasons.IndexOf(_currentSeason);

            _seasons = CalculatorQuest.GetMainQuestSeasons();

            if (seasonIndex > -1)
                _currentSeason = _seasons[seasonIndex];

            return _seasons;
        }

        private List<MainQuestChapterData> GetChapters(int seasonIndex)
        {
            var chapterIndex = -1;
            if (_currentChapter != null)
                chapterIndex = _chapters.IndexOf(_currentChapter);

            _chapters = CalculatorQuest.GetMainQuestChapters(_seasons[seasonIndex].MainQuestSeasonId);

            if (chapterIndex > -1)
                _currentChapter = _chapters[chapterIndex];

            return _chapters;
        }

        private List<QuestCellData> GetQuests(int chapterIndex)
        {
            _difficulties = _chapters[chapterIndex].MainQuestChapterDifficultyTypes;
            UpdateCurrentDifficulty();

            return _quests = CalculatorQuest.GenerateMainQuestData(_chapters[chapterIndex].MainQuestChapterId, _currentDifficulty).QuestDataList;
        }
        private void UpdateCurrentDifficulty(DifficultyType diffType)
        {
            _currentDifficulty = diffType;
            if (!_difficulties.Contains(diffType))
                _currentDifficulty = DefaultDifficulty;

            UpdateCurrentDifficulty();
        }

        private void UpdateCurrentDifficulty()
        {
            if (!_difficulties.Contains(_currentDifficulty))
                _currentDifficulty = _difficulties[^1];

            SetDifficulty(_currentDifficulty);
        }

        private void UpdateChapters(int seasonIndex)
        {
            SetChapterList(CreateChapterButtonList(seasonIndex));

            foreach (var chapterBtn in chapterButtonList)
                chapterBtn.Clicked += ChapterBtn_Clicked;
        }

        private void UpdateQuests(int chapterIndex)
        {
            SetQuestList(CreateQuestButtonList(chapterIndex));

            foreach (var questBtn in questButtonList)
                questBtn.Clicked += QuestBtn_Clicked;
        }
    }
}
