using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImGui.Forms.Controls;
using ImGui.Forms.Controls.Layouts;
using ImGuiNET;
using nier_rein_gui.Dialogs.FarmDialogs;
using nier_rein_gui.Forms.Panels.SubQuests.Quests.Base;
using NierReincarnation;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Component.Story;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.View.UserInterface;
using NierReincarnation.Core.Dark.View.UserInterface.Outgame;

namespace nier_rein_gui.Forms.Panels.SubQuests.Characters.Base
{
    class CharacterQuestListPanel : ClosableQuestListPanel<EventQuestData>
    {
        private readonly NierReinContexts _rein;
        private readonly IList<CharacterQuestChapterData> _chapters;
        private readonly bool _isEndQuest;

        private CharacterQuestChapterData _currentChapter;

        public CharacterQuestListPanel(NierReinContexts reinContexts, CharacterQuestChapterData currentChapter, IList<CharacterQuestChapterData> chapters, bool isEndQuest) :
            base(CalculatorCharacter.GetCharacterName(currentChapter.CharacterId), new[] { DifficultyType.NORMAL })
        {
            _rein = reinContexts;
            _chapters = chapters;
            _isEndQuest = isEndQuest;

            _currentChapter = currentChapter;

            UpdateQuestList(CurrentDifficulty);
        }

        protected override IQuest GetBaseQuest(EventQuestData quest)
        {
            return quest.Quest;
        }

        protected override string GetQuestName(EventQuestData quest)
        {
            return quest.QuestName;
        }

        protected override IList<EventQuestData> GetQuestsByDifficulty(DifficultyType difficulty)
        {
            IEnumerable<EventQuestData> quests = CalculatorQuest.GenerateEventQuestData(_currentChapter.EventQuestChapterId, CurrentDifficulty);
            quests = quests.Where(x => x.IsAvailable);

            if (_isEndQuest)
                quests = quests.Where(x => !x.IsLock || x.ClearCount > 0);

            return quests.ToList();
        }

        protected override async Task FightAsync(IList<EventQuestData> quests, EventQuestData quest)
        {
            if (_isEndQuest && quest.Quest.EntityQuest.DailyClearableCount > 0)
            {
                var retreatDlg = new RetreatFarmDialog(_rein, quest);
                await retreatDlg.ShowAsync();
            }
            else
            {
                var deckType = _isEndQuest ? DeckType.QUEST : DeckType.RESTRICTED_QUEST;

                var farmDlg = new EventQuestFarmDialog(_rein, quests.Where(x => x.Quest.EntityQuest.DailyClearableCount <= 0).ToList(), quest, deckType);
                await farmDlg.ShowAsync();
            }
        }

        protected override void InitializeComponent(StackLayout listLayout)
        {
            // Add left, right, and back buttons
            var backBtn = new ArrowButton { Direction = ImGuiDir.Left };
            backBtn.Clicked += BackBtn_Clicked;

            var prevBtn = new ArrowButton { Direction = ImGuiDir.Left };
            prevBtn.Clicked += PrevBtn_Clicked;

            var nextBtn = new ArrowButton { Direction = ImGuiDir.Right };
            nextBtn.Clicked += NextBtn_Clicked;

            (listLayout.Items[0].Content as StackLayout).Items.Insert(0, backBtn);
            (listLayout.Items[1].Content as StackLayout).Items.Insert(0, new StackItem(prevBtn) { VerticalAlignment = VerticalAlignment.Center });
            (listLayout.Items[1].Content as StackLayout).Items.Add(new StackItem(nextBtn) { VerticalAlignment = VerticalAlignment.Center });
        }

        private void BackBtn_Clicked(object sender, EventArgs e)
        {
            OnClose();
        }

        private void PrevBtn_Clicked(object sender, EventArgs e)
        {
            var prevIndex = GetPreviousChapterIndex(_currentChapter);

            _currentChapter = _chapters[prevIndex];
            UpdateQuestList(DifficultyType.NORMAL);

            UpdateName(CalculatorCharacter.CharacterName(_currentChapter.CharacterId, true));
        }

        private void NextBtn_Clicked(object sender, EventArgs e)
        {
            var nextIndex = GetNextChapterIndex(_currentChapter);

            _currentChapter = _chapters[nextIndex];
            UpdateQuestList(DifficultyType.NORMAL);

            UpdateName(CalculatorCharacter.CharacterName(_currentChapter.CharacterId, true));
        }

        private int GetPreviousChapterIndex(CharacterQuestChapterData chapter)
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

        private int GetNextChapterIndex(CharacterQuestChapterData chapter)
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
    }
}
