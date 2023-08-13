using ImGui.Forms.Controls;
using NierReincarnation.App.Forms.Panels.SubQuests.Base;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.View.UserInterface;
using System.Collections.Generic;

namespace NierReincarnation.App.Forms.Panels.SubQuests
{
    internal class MainQuestSeasonPanel : SeasonPanel<MainQuestSeasonData>
    {
        public MainQuestSeasonPanel(NierReinContexts rein) : base(rein)
        {
        }

        protected override string GetSeasonName(MainQuestSeasonData season)
        {
            return season.MainQuestSeasonName;
        }

        protected override IList<MainQuestSeasonData> GetSeasons()
        {
            return CalculatorQuest.GetMainQuestSeasons();
        }

        protected override Panel GetChapterPanel(NierReinContexts rein, MainQuestSeasonData season)
        {
            return new MainQuestChapterPanel(rein, CalculatorQuest.GetMainQuestChapters(season.MainQuestSeasonId));
        }
    }
}
