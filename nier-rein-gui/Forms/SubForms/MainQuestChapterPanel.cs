using System;
using System.Collections.Generic;
using ImGui.Forms.Controls;
using nier_rein_gui.Controls.Buttons;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.View.UserInterface;

namespace nier_rein_gui.Forms.SubForms
{
    partial class MainQuestChapterPanel : Panel
    {
        public MainQuestChapterPanel()
        {
            InitializeComponent();
        }

        private List<MainQuestSeasonData> GetSeasons()
        {
            return CalculatorQuest.GetMainQuestSeasons();
        }

        private List<MainQuestChapterData> GetChapters(MainQuestSeasonData season)
        {
            return CalculatorQuest.GetMainQuestChapters(season.MainQuestSeasonId);
        }

        //private void UpdateChapters(MainQuestSeasonData season)
        //{
        //    _chapters = CalculatorQuest.GetMainQuestChapters(season.MainQuestSeasonId);
        //    _currentChapter = _chapters[0];

        //    //UpdateDifficulty(DefaultDifficulty_);
        //    //UpdateQuests(_currentChapter, DefaultDifficulty_);
        //}
    }
}
