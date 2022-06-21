using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using ImGui.Forms.Controls;
using ImGui.Forms.Controls.Layouts;
using ImGui.Forms.Controls.Lists;
using ImGui.Forms.Models;
using ImGuiNET;
using nier_rein_gui.Controls;
using nier_rein_gui.Controls.Buttons;
using nier_rein_gui.Dialogs;
using nier_rein_gui.Resources;
using NierReincarnation;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.View.UserInterface;
using NierReincarnation.Core.Dark.View.UserInterface.Outgame;

namespace nier_rein_gui.Forms.SubForms
{
    class CharacterQuestPanel : Panel
    {
        private readonly NierReinContexts _rein;
        private readonly IList<CharacterQuestChapterData> _chapters;

        public CharacterQuestPanel(NierReinContexts rein)
        {
            _rein = rein;
            _chapters = _rein.Quests.GetCharacterEventChapters();

            SetMainList();
        }

        private void SetMainList()
        {
            var list = new List
            {
                ItemSpacing = 5
            };

            foreach (var characterChapter in _chapters)
            {
                var charButton = new NierButton
                {
                    Caption = CalculatorCharacter.CharacterName(characterChapter.CharacterId, true),
                    Enabled = !characterChapter.IsLock
                };
                charButton.Clicked += (s, e) => SetQuestList(characterChapter);

                list.Items.Add(charButton);
            }

            Content = list;
        }

        private void SetQuestList(CharacterQuestChapterData chapter)
        {
            var list = new List
            {
                ItemSpacing = 5
            };

            var quests = _rein.Quests.GetEventQuests(chapter.EventQuestChapterId, DifficultyType.NORMAL).Where(x => x.IsAvailable).ToList();
            foreach (var quest in quests)
            {
                var charButton = new NierQuestButton
                {
                    Caption = quest.QuestName,
                    SuggestedPower = quest.RecommendPower,
                    Stamina = quest.Quest.EntityQuest.Stamina,
                    Padding = new Vector2(2, 2),
                    Enabled = !quest.IsLock
                };
                charButton.Clicked += async (s, e) => await FightAsync(chapter, quests, quest);

                list.Items.Add(charButton);
            }

            var prevIndex = GetPreviousChapterIndex(chapter);
            var nextIndex = GetNextChapterIndex(chapter);

            var backBtn = new ArrowButton { Direction = ImGuiDir.Left };
            backBtn.Clicked += BackBtn_Clicked;

            var prevBtn = new ArrowButton { Direction = ImGuiDir.Left };
            prevBtn.Clicked += (s, e) => SetQuestList(_chapters[prevIndex]);

            var nextBtn = new ArrowButton { Direction = ImGuiDir.Right };
            nextBtn.Clicked += (s, e) => SetQuestList(_chapters[nextIndex]);

            Content = new StackLayout
            {
                Alignment = Alignment.Vertical,
                ItemSpacing = 5,
                Items =
                {
                    new StackLayout
                    {
                        Alignment = Alignment.Horizontal,
                        Size = new Size(1f,-1),
                        ItemSpacing = 5,
                        Items =
                        {
                            backBtn,
                            new Label{Caption = CalculatorCharacter.CharacterName(chapter.CharacterId, true),Font = FontResources.FotRodin(20)}
                        }
                    },
                    new StackLayout
                    {
                        Alignment = Alignment.Horizontal,
                        ItemSpacing = 5,
                        Items =
                        {
                            new StackItem(prevBtn){VerticalAlignment = VerticalAlignment.Center},
                            list,
                            new StackItem(nextBtn){VerticalAlignment = VerticalAlignment.Center}
                        }
                    }
                }
            };
        }

        private void BackBtn_Clicked(object sender, System.EventArgs e)
        {
            SetMainList();
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

        private async Task FightAsync(CharacterQuestChapterData chapter, IList<EventQuestData> quests, EventQuestData quest)
        {
            var farmDlg = new EventQuestFarmDialog(_rein, chapter.EventQuestChapterId, quests, quest);
            await farmDlg.ShowAsync();

            SetQuestList(chapter);
        }
    }
}
