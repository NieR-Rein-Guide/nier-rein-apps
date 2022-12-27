using System.Collections.Generic;
using ImGui.Forms.Controls;
using ImGui.Forms.Controls.Layouts;
using ImGui.Forms.Modals;
using nier_rein_gui.Controls.Buttons;
using nier_rein_gui.Dialogs.FarmDialogs;
using nier_rein_gui.Forms.Panels.Map;
using nier_rein_gui.Forms.Panels.SubQuests.Base;
using nier_rein_gui.Resources;
using NierReincarnation;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.View.UserInterface;

namespace nier_rein_gui.Forms.Panels
{
    class MapSeasonPanel : SeasonPanel<MainQuestSeasonData>
    {
        private readonly NierReinContexts _rein;
        private readonly MainForm _mainForm;

        public MapSeasonPanel(NierReinContexts rein, MainForm mainForm) : base(rein)
        {
            _rein = rein;
            _mainForm = mainForm;
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
            return new MapChapterPanel(rein, CalculatorQuest.GetMainQuestChapters(season.MainQuestSeasonId));
        }

        protected override void UpdateLayout(StackLayout layout)
        {
            var collectAllBtn = new NierButton
            {
                Caption = LocalizationResources.CollectAllItems,
                Enabled = ClearAllMapItemsDialog.HasCollectableGimmicks()
            };
            collectAllBtn.Clicked += CollectAllBtn_Clicked;

            layout.Items[0] = new StackLayout
            {
                Alignment = Alignment.Horizontal,
                ItemSpacing = 5,
                Size = layout.Items[0].Size,
                Items =
                {
                    layout.Items[0],
                    collectAllBtn
                }
            };
        }

        private async void CollectAllBtn_Clicked(object sender, System.EventArgs e)
        {
            ((NierButton)sender).Enabled = false;

            var result = await new ClearAllMapItemsDialog(_rein).ShowAsync();
            if (result != DialogResult.Ok)
                ((NierButton)sender).Enabled = true;

            UpdateChapterPanel(CurrentSeason);
        }
    }
}
