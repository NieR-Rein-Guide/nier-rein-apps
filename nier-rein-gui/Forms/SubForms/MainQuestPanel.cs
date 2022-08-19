using System.Collections.Generic;
using ImGui.Forms.Controls;
using NierReincarnation;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Core.Dark.View.UserInterface;
using NierReincarnation.Core.Dark.View.UserInterface.Outgame;
using NierReincarnation.Core.Dark.View.UserInterface.Text;

namespace nier_rein_gui.Forms.SubForms
{
    partial class MainQuestPanel : Panel
    {
        private readonly NierReinContexts _rein;

        public MainQuestPanel(NierReinContexts rein)
        {
            _rein = rein;

            InitializeComponent();

            chapterPanel.UpdateChapter += ChapterPanel_UpdateChapter;
            difficultyButton.Clicked += DifficultyButton_Clicked;
        }

        private List<QuestCellData> GetQuests(MainQuestChapterData chapter, DifficultyType difficulty)
        {
            return CalculatorQuest.GenerateMainQuestData(chapter.MainQuestChapterId, difficulty).QuestDataList;
        }

        private void UpdateDifficulty(DifficultyType difficultyType)
        {
            _currentDifficulty = difficultyType;

            difficultyButton.Caption = string.Format(UserInterfaceTextKey.Quest.kQuestDifficulty, (int)difficultyType).Localize();
        }

        #region Events

        private void ChapterPanel_UpdateChapter(MainQuestSeasonData season, MainQuestChapterData chapter)
        {
            var difficulties = chapter.MainQuestChapterDifficultyTypes;
            var difficulty = _currentDifficulty;

            if (!difficulties.Contains(_currentDifficulty))
                difficulty = difficulties[0];

            UpdateDifficulty(difficulty);
            UpdateQuestList(chapter, difficulty);
        }

        private void DifficultyButton_Clicked(object sender, System.EventArgs e)
        {
            var newDifficulty = _currentDifficulty + 1;
            if (!chapterPanel.CurrentChapter.MainQuestChapterDifficultyTypes.Contains(newDifficulty))
                newDifficulty = chapterPanel.CurrentChapter.MainQuestChapterDifficultyTypes[0];

            UpdateDifficulty(newDifficulty);
            UpdateQuestList(chapterPanel.CurrentChapter, newDifficulty);
        }

        #endregion

        //private void DifficultyButton_Clicked1(object sender, System.EventArgs e)
        //{
        //    var newDifficulty = _currentDifficulty + 1;
        //    if (!_currentChapter.MainQuestChapterDifficultyTypes.Contains(newDifficulty))
        //        newDifficulty = _currentChapter.MainQuestChapterDifficultyTypes[0];

        //    UpdateDifficulty(newDifficulty);
        //    UpdateQuests(_currentChapter, newDifficulty);
        //}

        //private async void QuestBtn_Clicked(NierQuestButton sender, QuestCellData quest)
        //{
        //    var farmDlg = new MainQuestFarmDialog(_rein, _quests, quest);
        //    await farmDlg.ShowAsync();

        //    UpdateQuests(_currentChapter, _currentDifficulty);
        //}
    }
}
