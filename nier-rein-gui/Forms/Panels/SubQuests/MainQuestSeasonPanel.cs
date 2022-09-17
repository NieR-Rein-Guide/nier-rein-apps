using System.Collections.Generic;
using ImGui.Forms.Controls;
using nier_rein_gui.Forms.Panels.SubQuests.Base;
using NierReincarnation;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.View.UserInterface;

namespace nier_rein_gui.Forms.Panels.SubQuests
{
    class MainQuestSeasonPanel : SeasonPanel<MainQuestSeasonData>
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
