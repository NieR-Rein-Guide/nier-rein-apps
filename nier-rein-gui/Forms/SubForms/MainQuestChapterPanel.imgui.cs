using System;
using System.Collections.Generic;
using System.Numerics;
using ImGui.Forms.Controls.Base;
using ImGui.Forms.Controls.Layouts;
using ImGui.Forms.Controls.Lists;
using ImGui.Forms.Models;
using nier_rein_gui.Controls.Buttons;
using NierReincarnation.Core.Dark.Calculator;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.View.UserInterface;

namespace nier_rein_gui.Forms.SubForms
{
    partial class MainQuestChapterPanel
    {
        private List<MainQuestSeasonData> _seasons;
        private List<MainQuestChapterData> _chapters;

        private StackLayout seasonLayout;
        private List chapterList;

        public event Action<MainQuestSeasonData, MainQuestChapterData> UpdateChapter;

        public MainQuestSeasonData CurrentSeason { get; private set; }
        public MainQuestChapterData CurrentChapter { get; private set; }

        private void InitializeComponent()
        {
            seasonLayout = new StackLayout
            {
                Alignment = Alignment.Horizontal,
                ItemSpacing = 5,
                Size = new Size(1f, -1)
            };
            chapterList = new List { ItemSpacing = 5 };

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
                            new StackItem(chapterList){Size = new Size(.35f,1f)}
                            //new StackLayout
                            //{
                            //    Alignment = Alignment.Vertical,
                            //    ItemSpacing = 5,
                            //    Size = new Size(.65f, 1f),
                            //    Items =
                            //    {
                            //        new StackItem(difficultyButton){HorizontalAlignment = HorizontalAlignment.Right},
                            //        questList
                            //    }
                            //}
                        }
                    }
                }
            };

            UpdateSeasonList();
            UpdateChapterList(_seasons[0]);
        }

        public void SetContent(Component content)
        {
            var items = ((Content as StackLayout).Items[1].Content as StackLayout).Items;
            var item = new StackItem(content) {Size = new Size(.65f, 1f)};

            if (items.Count < 2)
                items.Add(item);
            else
                items.Insert(1, item);
        }

        #region Create lists

        private void UpdateSeasonList()
        {
            // Clear layout
            for (var i = seasonLayout.Items.Count - 1; i >= 0; i++)
                seasonLayout.Items.RemoveAt(i);

            // Add seasons
            _seasons = GetSeasons();
            foreach (var season in _seasons)
                seasonLayout.Items.Add(CreateSeasonButton(_seasons[0], season));

            CurrentSeason = _seasons[0];
        }

        private void UpdateChapterList(MainQuestSeasonData season)
        {
            // Clear list
            chapterList.Items.Clear();

            // Add chapters
            _chapters = GetChapters(season);
            foreach (var chapter in _chapters)
                chapterList.Items.Add(CreateChapterButton(season, _chapters[0], chapter));

            CurrentChapter = _chapters[0];
            UpdateChapter?.Invoke(season, _chapters[0]);
        }

        #endregion

        #region Create button

        private NierButton CreateSeasonButton(MainQuestSeasonData currentSeason, MainQuestSeasonData season)
        {
            var result = new NierButton
            {
                Caption = season.MainQuestSeasonName,
                Active = currentSeason == season,
                IsClickActive = true,
                Width = 0.125f,
                Padding = new Vector2(0, 2)
            };
            result.Clicked += (s, e) => SeasonBtn_Clicked((NierButton)s, season);

            return result;
        }

        private NierButton CreateChapterButton(MainQuestSeasonData season, MainQuestChapterData currentChapter, MainQuestChapterData chapter)
        {
            var result = new NierButton
            {
                Caption = chapter.MainQuestChapterNumberName,
                Active = currentChapter == chapter,
                Enabled = CalculatorQuest.IsUnlockMainQuestChapter(CalculatorStateUser.GetUserId(), chapter.MainQuestChapterId),
                IsClickActive = true,
                Width = 1f,
                Padding = new Vector2(0, 2)
            };
            result.Clicked += (s, e) => ChapterBtn_Clicked((NierButton)s, season, chapter);

            return result;
        }

        #endregion

        #region Button events

        private void SeasonBtn_Clicked(NierButton sender, MainQuestSeasonData season)
        {
            foreach (var seasonBtn in seasonLayout.Items)
                (seasonBtn.Content as NierButton).Active = sender == seasonBtn.Content;

            CurrentSeason = season;
            UpdateChapterList(season);
        }

        private void ChapterBtn_Clicked(NierButton sender, MainQuestSeasonData season, MainQuestChapterData chapter)
        {
            foreach (var chapterBtn in chapterList.Items)
                (chapterBtn as NierButton).Active = chapterBtn == sender;

            CurrentChapter = chapter;
            UpdateChapter?.Invoke(season, chapter);

            //var difficulties = chapter.MainQuestChapterDifficultyTypes;
            //var difficulty = _currentDifficulty;

            //if (!difficulties.Contains(_currentDifficulty))
            //    difficulty = difficulties[0];

            //UpdateDifficulty(difficulty);
            //UpdateQuests(chapter, difficulty);
        }

        #endregion
    }
}
