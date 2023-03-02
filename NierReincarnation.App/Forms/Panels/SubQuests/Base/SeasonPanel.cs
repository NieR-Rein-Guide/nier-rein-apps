using System.Collections.Generic;
using ImGui.Forms.Controls;
using NierReincarnation;

namespace NierReincarnation.App.Forms.Panels.SubQuests.Base
{
    abstract partial class SeasonPanel<TSeasonData> : Panel
    {
        private readonly NierReinContexts _rein;

        protected SeasonPanel(NierReinContexts rein)
        {
            _rein = rein;

            InitializeComponent();

            UpdateSeasonList(GetSeasons());
            UpdateChapterPanel(CurrentSeason);
        }

        protected abstract IList<TSeasonData> GetSeasons();

        protected abstract string GetSeasonName(TSeasonData season);

        protected abstract Panel GetChapterPanel(NierReinContexts rein, TSeasonData season);
    }
}
