using ImGui.Forms.Controls;
using NierReincarnation.App.Controls.Base;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.View.UserInterface.Outgame;
using System;
using System.Collections.Generic;

namespace NierReincarnation.App.Forms.Panels.SubQuests.Characters.LimitQuest
{
    internal partial class LimitQuestBundlePanel : Panel, IClosablePanel
    {
        private readonly NierReinContexts _rein;
        private readonly IList<DataLimitContentCharacter> _chapters;

        private DataLimitContentCharacter _currentChapter;
        private IList<DifficultyType> _difficulties;

        protected DifficultyType CurrentDifficulty { get; private set; }

        public event EventHandler Closed;

        public LimitQuestBundlePanel(NierReinContexts rein, DataLimitContentCharacter currentChapter, IList<DataLimitContentCharacter> chapters)
        {
            _rein = rein;
            _chapters = chapters;

            _currentChapter = currentChapter;

            _difficulties = CalculatorLimitContent.CreateLimitContentDifficulties(currentChapter.EventQuestLimitContentId);
            InitializeComponent(currentChapter.Costume.CharacterName, _difficulties);

            CurrentDifficulty = _difficulties[0];
            UpdateQuestBundleList(currentChapter, CurrentDifficulty);

            difficultyBtn.Clicked += DifficultyButton_Clicked;
            prevBtn.Clicked += PrevBtn_Clicked;
            nextBtn.Clicked += NextBtn_Clicked;
            backBtn.Clicked += BackBtn_Clicked;
        }

        private void BackBtn_Clicked(object sender, EventArgs e)
        {
            OnClosed();
        }

        private void DifficultyButton_Clicked(object sender, EventArgs e)
        {
            var diffIndex = _difficulties.IndexOf(CurrentDifficulty);

            diffIndex++;
            if (diffIndex >= _difficulties.Count)
                diffIndex = 0;

            CurrentDifficulty = _difficulties[diffIndex];
            UpdateDifficultyText(CurrentDifficulty);

            UpdateQuestBundleList(_currentChapter, CurrentDifficulty);
        }

        private void PrevBtn_Clicked(object sender, EventArgs e)
        {
            var prevIndex = GetPreviousChapterIndex(_currentChapter);

            _currentChapter = _chapters[prevIndex];

            _difficulties = CalculatorLimitContent.CreateLimitContentDifficulties(_currentChapter.EventQuestLimitContentId);
            CurrentDifficulty = _difficulties[0];
            UpdateDifficultyText(CurrentDifficulty);

            UpdateQuestBundleList(_currentChapter, CurrentDifficulty);

            UpdateName(_currentChapter.Costume.CharacterName);
        }

        private void NextBtn_Clicked(object sender, EventArgs e)
        {
            var nextIndex = GetNextChapterIndex(_currentChapter);

            _currentChapter = _chapters[nextIndex];

            _difficulties = CalculatorLimitContent.CreateLimitContentDifficulties(_currentChapter.EventQuestLimitContentId);
            CurrentDifficulty = _difficulties[0];
            UpdateDifficultyText(CurrentDifficulty);

            UpdateQuestBundleList(_currentChapter, CurrentDifficulty);

            UpdateName(_currentChapter.Costume.CharacterName);
        }

        private int GetPreviousChapterIndex(DataLimitContentCharacter chapter)
        {
            var index = _chapters.IndexOf(chapter);
            for (var i = index - 1; i > index - _chapters.Count; i--)
            {
                var localIndex = i;
                if (localIndex < 0)
                    localIndex = _chapters.Count + i;

                if (!_chapters[localIndex].IsLock)
                    return localIndex;
            }

            return index;
        }

        private int GetNextChapterIndex(DataLimitContentCharacter chapter)
        {
            var index = _chapters.IndexOf(chapter);
            for (var i = index + 1; i < _chapters.Count + index; i++)
            {
                var localIndex = i;
                if (localIndex >= _chapters.Count)
                    localIndex = i - _chapters.Count;

                if (!_chapters[localIndex].IsLock)
                    return localIndex;
            }

            return index;
        }

        private void OnClosed()
        {
            Closed?.Invoke(this, EventArgs.Empty);
        }
    }
}
