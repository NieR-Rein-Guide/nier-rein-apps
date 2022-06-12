using ImGui.Forms.Controls;
using nier_rein_gui.Controls;
using NierReincarnation;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.View.UserInterface;
using NierReincarnation.Core.Dark.View.UserInterface.Outgame;

namespace nier_rein_gui.Forms.SubForms
{
    partial class MainQuestPanel : Panel
    {
        private readonly NierReinContexts _rein;

        //private List<MainQuestSeasonData> _seasons;
        //private List<MainQuestChapterData> _chapters;
        //private List<QuestCellData> _quests;
        //private List<DifficultyType> _difficulties;

        //private MainQuestSeasonData _currentSeason;
        //private MainQuestChapterData _currentChapter;
        //private DifficultyType _currentDifficulty = DefaultDifficulty_;

        public MainQuestPanel(NierReinContexts rein)
        {
            _rein = rein;

            InitializeComponent();

            //_currentSeason = _seasons[0];
            //_currentChapter = _chapters[0];

            //foreach (var seasonBtn in seasonButtonList)
            //    seasonBtn.Clicked += SeasonBtn_Clicked;
            //foreach (var chapterBtn in chapterButtonList)
            //    chapterBtn.Clicked += ChapterBtn_Clicked;
            //foreach (var questBtn in questButtonList)
            //    questBtn.Clicked += QuestBtn_Clicked;

            //difficultyButton.Clicked += DifficultyButton_Clicked;
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

        //private void DifficultyButton_Clicked(NierButton sender, DifficultyType difficulty)
        //{
        //    var newDifficulty = difficulty + 1;
        //    if (!_currentChapter.MainQuestChapterDifficultyTypes.Contains(newDifficulty))
        //        newDifficulty = _currentChapter.MainQuestChapterDifficultyTypes[0];

        //    UpdateDifficulty(newDifficulty);
        //    UpdateQuests(_currentChapter, newDifficulty);
        //}

        private async void QuestBtn_Clicked(NierQuestButton sender, QuestCellData quest)
        {
            //var index = questButtonList.IndexOf((NierQuestButton)sender);
            //if (index < 0 || _quests.Count <= index)
            //    return;

            //var farmDlg = new MainQuestFarmDialog(_rein, _quests, _quests[index]);
            //await farmDlg.ShowAsync();

            //var seasonIndex = _seasons.IndexOf(_currentSeason);
            //var chapterIndex = _chapters.IndexOf(_currentChapter);

            //UpdateChapters(seasonIndex);
            //UpdateQuests(chapterIndex);
        }

        //private List<MainQuestSeasonData> GetSeasons()
        //{
        //    return _seasons = CalculatorQuest.GetMainQuestSeasons();
        //}

        //private List<MainQuestChapterData> GetChapters(int seasonIndex)
        //{
        //    return _chapters = CalculatorQuest.GetMainQuestChapters(_seasons[seasonIndex].MainQuestSeasonId);
        //}

        //private List<DifficultyType> GetDifficulties(int chapterIndex)
        //{
        //    return _difficulties = _chapters[chapterIndex].MainQuestChapterDifficultyTypes;
        //}

        //private List<QuestCellData> GetQuests(int chapterIndex, DifficultyType difficultyType)
        //{
        //    _currentDifficulty = difficultyType;
        //    return _quests = CalculatorQuest.GenerateMainQuestData(_chapters[chapterIndex].MainQuestChapterId, _currentDifficulty).QuestDataList;
        //}

        //private void UpdateCurrentDifficulty(DifficultyType diffType)
        //{
        //    _currentDifficulty = diffType;
        //    if (!_difficulties.Contains(diffType))
        //        _currentDifficulty = DefaultDifficulty_;

        //    UpdateCurrentDifficulty();
        //}

        //private void UpdateCurrentDifficulty()
        //{
        //    if (!_difficulties.Contains(_currentDifficulty))
        //        _currentDifficulty = _difficulties[^1];

        //    SetDifficulty(_currentDifficulty);
        //}

        //private void UpdateChapters(int seasonIndex)
        //{
        //    SetChapterList(CreateChapterButtonList(seasonIndex));

        //    foreach (var chapterBtn in chapterButtonList)
        //        chapterBtn.Clicked += ChapterBtn_Clicked;
        //}

        //private void UpdateQuests(int chapterIndex)
        //{
        //    SetQuestList(CreateQuestButtonList(chapterIndex));

        //    foreach (var questBtn in questButtonList)
        //        questBtn.Clicked += QuestBtn_Clicked;
        //}
    }
}
