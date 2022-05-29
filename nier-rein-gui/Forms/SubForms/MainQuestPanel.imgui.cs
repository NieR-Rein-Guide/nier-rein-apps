using System.Collections.Generic;
using System.Numerics;
using ImGui.Forms.Controls.Layouts;
using ImGui.Forms.Controls.Lists;
using ImGui.Forms.Models;
using nier_rein_gui.Controls;
using nier_rein_gui.Resources;
using NierReincarnation.Core.Dark.Calculator;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Core.Dark.View.UserInterface.Text;

namespace nier_rein_gui.Forms.SubForms
{
    partial class MainQuestPanel
    {
        private const DifficultyType DefaultDifficulty = DifficultyType.NORMAL;

        private List<NierButton> seasonButtonList;
        private List<NierButton> chapterButtonList;
        private List<NierQuestButton> questButtonList;
        private NierButton difficultyButton;

        private void InitializeComponent()
        {
            seasonButtonList = new List<NierButton>();
            chapterButtonList = new List<NierButton>();
            questButtonList = new List<NierQuestButton>();
            difficultyButton = new NierButton
            {
                Width = 100
            };

            Content = new StackLayout
            {
                Alignment = Alignment.Vertical,
                ItemSpacing = 5,
                Items =
                {
                    CreateSeasonButtonLayout(),
                    new StackLayout
                    {
                        Alignment = Alignment.Horizontal,
                        ItemSpacing = 5,
                        Items =
                        {
                            new StackItem(null),
                            new StackLayout
                            {
                                Alignment = Alignment.Vertical,
                                ItemSpacing = 5,
                                Size = new Size(.65f, 1f),
                                Items =
                                {
                                    new StackItem(difficultyButton){HorizontalAlignment = HorizontalAlignment.Right},
                                    new StackItem(null)
                                }
                            }
                        }
                    }
                }
            };

            SetChapterList(CreateChapterButtonList());
            SetQuestList(CreateQuestButtonList());
            SetDifficulty(DefaultDifficulty);
        }

        private StackLayout CreateSeasonButtonLayout()
        {
            seasonButtonList.Clear();

            var result = new StackLayout
            {
                Alignment = Alignment.Horizontal,
                ItemSpacing = 5,
                Size = new Size(1f, -1)
            };

            // TODO: Set Enabled based on user status for story progress

            var seasons = GetSeasons();
            foreach (var season in seasons)
            {
                var seasonBtn = new NierButton
                {
                    Caption = season.MainQuestSeasonName,
                    Active = seasons[0] == season,
                    IsClickActive = true,
                    Width = 0.125f,
                    Padding = new Vector2(0, 2)
                };

                seasonButtonList.Add(seasonBtn);
                result.Items.Add(new StackItem(seasonBtn));
            }

            return result;
        }

        private List CreateChapterButtonList(int seasonIndex = 0)
        {
            chapterButtonList.Clear();

            var result = new List
            {
                ItemSpacing = 5
            };

            // TODO: Set Enabled/Visible based on user status for story progress
            var chapters = GetChapters(seasonIndex);
            foreach (var chapter in chapters)
            {
                var chapterBtn = new NierButton
                {
                    Caption = chapter.MainQuestChapterNumberName,
                    Active = chapters[0] == chapter,
                    Enabled = CalculatorQuest.IsUnlockMainQuestChapter(CalculatorStateUser.GetUserId(), chapter.MainQuestChapterId),
                    IsClickActive = true,
                    Width = 0.2f,
                    Padding = new Vector2(0, 2)
                };

                chapterButtonList.Add(chapterBtn);
                result.Items.Add(chapterBtn);
            }

            return result;
        }

        private List CreateQuestButtonList(int chapterIndex = 0)
        {
            questButtonList.Clear();

            var result = new List
            {
                ItemSpacing = 5
            };

            // TODO: Set Enabled/Visible based on user status for story progress
            var quests = GetQuests(chapterIndex);
            foreach (var quest in quests)
            {
                var questBtn = new NierQuestButton
                {
                    Caption = quest.QuestName,
                    Enabled = !quest.IsLock,
                    SubFont = FontResources.FotRodin(12),
                    DailyFont = FontResources.FotRodin(9),
                    ClearFont = FontResources.FotRodin(11),
                    SuggestedPower = quest.Quest.EntityQuest.RecommendedDeckPower,
                    Stamina = quest.Quest.EntityQuest.Stamina,
                    Padding = new Vector2(2, 2)
                };

                questButtonList.Add(questBtn);
                result.Items.Add(questBtn);
            }

            return result;
        }

        private void SetChapterList(List chapterList)
        {
            ((Content as StackLayout).Items[1].Content as StackLayout).Items[0] = new StackItem(chapterList) { Size = new Size(.35f, 1f) };
        }

        private void SetQuestList(List questList)
        {
            (((Content as StackLayout).Items[1].Content as StackLayout).Items[1].Content as StackLayout).Items[1] = new StackItem(questList);
        }

        private void SetDifficulty(DifficultyType diffType)
        {
            ((((Content as StackLayout).Items[1].Content as StackLayout).Items[1].Content as StackLayout).Items[0].Content as NierButton).Caption =
                string.Format(UserInterfaceTextKey.Quest.kQuestDifficulty, (int)diffType).Localize();
        }
    }
}
