using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using ImGui.Forms.Controls.Layouts;
using ImGui.Forms.Controls.Lists;
using ImGui.Forms.Models;
using nier_rein_gui.Controls.Buttons;
using NierReincarnation.Core.Dark.Calculator;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Core.Dark.View.UserInterface;
using NierReincarnation.Core.Dark.View.UserInterface.Outgame;
using NierReincarnation.Core.Dark.View.UserInterface.Text;

namespace nier_rein_gui.Forms.SubForms
{
    partial class MainQuestPanel
    {
        private const DifficultyType DefaultDifficulty_ = DifficultyType.NORMAL;

        private List<MainQuestSeasonData> _seasons;
        private List<MainQuestChapterData> _chapters;
        private List<QuestCellData> _quests;

        private MainQuestSeasonData _currentSeason;
        private MainQuestChapterData _currentChapter;
        private DifficultyType _currentDifficulty;

        private StackLayout seasonLayout;
        private List chapterList;
        private List questList;
        private NierButton difficultyButton;

        private void InitializeComponent()
        {
            seasonLayout = CreateSeasonButtonLayout();
            chapterList = new List { ItemSpacing = 5 };
            questList = new List { ItemSpacing = 5, };
            difficultyButton = new NierButton { Width = 100 };

            Content = new StackLayout
            {
                Alignment = Alignment.Vertical,
                ItemSpacing = 5,
                Items =
                {
                    seasonLayout,
                    new StackLayout
                    {
                        Alignment = Alignment.Horizontal,
                        ItemSpacing = 5,
                        Items =
                        {
                            new StackItem(chapterList){Size = new Size(.35f,1f)},
                            new StackLayout
                            {
                                Alignment = Alignment.Vertical,
                                ItemSpacing = 5,
                                Size = new Size(.65f, 1f),
                                Items =
                                {
                                    new StackItem(difficultyButton){HorizontalAlignment = HorizontalAlignment.Right},
                                    questList
                                }
                            }
                        }
                    }
                }
            };

            UpdateChapters(_seasons[0]);
            difficultyButton.Clicked += DifficultyButton_Clicked1;
        }

        private void UpdateChapters(MainQuestSeasonData season)
        {
            _chapters = CalculatorQuest.GetMainQuestChapters(season.MainQuestSeasonId);
            _currentChapter = _chapters[0];

            chapterList.Items.Clear();
            foreach (var chapter in _chapters)
                chapterList.Items.Add(CreateChapterButton(chapter));

            UpdateDifficulty(DefaultDifficulty_);
            UpdateQuests(_currentChapter, DefaultDifficulty_);
        }

        private void UpdateDifficulty(DifficultyType difficultyType)
        {
            _currentDifficulty = difficultyType;

            difficultyButton.Caption = string.Format(UserInterfaceTextKey.Quest.kQuestDifficulty, (int)difficultyType).Localize();
        }

        private void UpdateQuests(MainQuestChapterData chapter, DifficultyType difficulty)
        {
            _quests = CalculatorQuest.GenerateMainQuestData(chapter.MainQuestChapterId, difficulty).QuestDataList;

            questList.Items.Clear();
            foreach (var quest in _quests)
                questList.Items.Add(CreateQuestButton(quest));
        }

        private NierButton CreateChapterButton(MainQuestChapterData chapter)
        {
            var result = new NierButton
            {
                Caption = chapter.MainQuestChapterNumberName,
                Active = _currentChapter == chapter,
                Enabled = CalculatorQuest.IsUnlockMainQuestChapter(CalculatorStateUser.GetUserId(), chapter.MainQuestChapterId),
                IsClickActive = true,
                Width = 1f,
                Padding = new Vector2(0, 2)
            };
            result.Clicked += (s, e) => ChapterBtn_Clicked((NierButton)s, chapter);

            return result;
        }

        private NierQuestButton CreateQuestButton(QuestCellData quest)
        {
            var campaigns = CalculatorCampaign.CreateDataQuestCampaignAll(quest.Quest);
            var stamCampaign = campaigns.TotalCampaignList.FirstOrDefault(x => (x as DataQuestCampaign).QuestCampaignEffectType == QuestCampaignEffectType.STAMINA_CONSUME_AMOUNT);

            var result = new NierQuestButton
            {
                Caption = quest.QuestName,
                Enabled = !quest.IsLock,
                SuggestedPower = quest.Quest.EntityQuest.RecommendedDeckPower,
                Stamina = quest.Quest.EntityQuest.Stamina,
                IsClear = quest.IsClear,
                Padding = new Vector2(2, 2),
                Width = 1f,
                StaminaCampaign = stamCampaign as DataQuestCampaign
            };
            result.Clicked += (s, e) => QuestBtn_Clicked((NierQuestButton)s, quest);

            return result;
        }

        // TODO: Make vertical List
        private StackLayout CreateSeasonButtonLayout()
        {
            var result = new StackLayout
            {
                Alignment = Alignment.Horizontal,
                ItemSpacing = 5,
                Size = new Size(1f, -1)
            };

            // TODO: Set Enabled based on user status for story progress

            _seasons = CalculatorQuest.GetMainQuestSeasons();
            foreach (var season in _seasons)
            {
                var seasonBtn = new NierButton
                {
                    Caption = season.MainQuestSeasonName,
                    Active = _seasons[0] == season,
                    IsClickActive = true,
                    Width = 0.125f,
                    Padding = new Vector2(0, 2)
                };
                seasonBtn.Clicked += (s, e) => SeasonBtn_Clicked((NierButton)s, season);

                result.Items.Add(seasonBtn);
            }

            _currentSeason = _seasons[0];

            return result;
        }

        //private List CreateChapterButtonList(int seasonIndex = 0)
        //{
        //    chapterButtonList.Clear();

        //    var result = new List
        //    {
        //        ItemSpacing = 5
        //    };

        //    // TODO: Set Enabled/Visible based on user status for story progress
        //    var chapters = GetChapters(seasonIndex);
        //    foreach (var chapter in chapters)
        //    {
        //        var chapterBtn = new NierButton
        //        {
        //            Caption = chapter.MainQuestChapterNumberName,
        //            Active = chapters[0] == chapter,
        //            Enabled = CalculatorQuest.IsUnlockMainQuestChapter(CalculatorStateUser.GetUserId(), chapter.MainQuestChapterId),
        //            IsClickActive = true,
        //            Width = 0.2f,
        //            Padding = new Vector2(0, 2)
        //        };

        //        chapterButtonList.Add(chapterBtn);
        //        result.Items.Add(chapterBtn);
        //    }

        //    return result;
        //}

        //private List CreateQuestButtonList(int chapterIndex = 0)
        //{
        //    questButtonList.Clear();

        //    var result = new List
        //    {
        //        ItemSpacing = 5
        //    };

        //    // TODO: Set Enabled/Visible based on user status for story progress
        //    var quests = GetQuests(chapterIndex);
        //    foreach (var quest in quests)
        //    {
        //        var questBtn = new NierQuestButton
        //        {
        //            Caption = quest.QuestName,
        //            Enabled = !quest.IsLock,
        //            SubFont = FontResources.FotRodin(12),
        //            DailyFont = FontResources.FotRodin(9),
        //            ClearFont = FontResources.FotRodin(11),
        //            SuggestedPower = quest.Quest.EntityQuest.RecommendedDeckPower,
        //            Stamina = quest.Quest.EntityQuest.Stamina,
        //            Padding = new Vector2(2, 2)
        //        };

        //        questButtonList.Add(questBtn);
        //        result.Items.Add(questBtn);
        //    }

        //    return result;
        //}

        //private void SetChapterList(List chapterList)
        //{
        //    ((Content as StackLayout).Items[1].Content as StackLayout).Items[0] = new StackItem(chapterList) { Size = new Size(.35f, 1f) };
        //}

        //private void SetQuestList(List questList)
        //{
        //    (((Content as StackLayout).Items[1].Content as StackLayout).Items[1].Content as StackLayout).Items[1] = new StackItem(questList);
        //}

        //private void SetDifficulty(DifficultyType diffType)
        //{
        //    ((((Content as StackLayout).Items[1].Content as StackLayout).Items[1].Content as StackLayout).Items[0].Content as NierButton).Caption =
        //        string.Format(UserInterfaceTextKey.Quest.kQuestDifficulty, (int)diffType).Localize();
        //}
    }
}
