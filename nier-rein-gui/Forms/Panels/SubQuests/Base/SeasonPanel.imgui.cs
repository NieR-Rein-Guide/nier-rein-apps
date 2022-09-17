using System.Collections.Generic;
using System.Numerics;
using ImGui.Forms.Controls.Layouts;
using ImGui.Forms.Models;
using nier_rein_gui.Controls.Buttons;

namespace nier_rein_gui.Forms.Panels.SubQuests.Base
{
    abstract partial class SeasonPanel<TSeasonData>
    {
        private StackLayout mainLayout;
        private StackLayout seasonLayout;

        protected TSeasonData CurrentSeason { get; set; }

        private void InitializeComponent()
        {
            seasonLayout = new StackLayout
            {
                Alignment = Alignment.Horizontal,
                ItemSpacing = 5,
                Size = new Size(1f, -1)
            };

            Content = mainLayout = new StackLayout
            {
                Alignment = Alignment.Vertical,
                ItemSpacing = 5,
                Items =
                {
                    seasonLayout,
                    new StackItem(null)
                }
            };
        }

        private void UpdateSeasonList(IList<TSeasonData> seasons)
        {
            CurrentSeason = seasons[0];

            // Clear layout
            for (var i = seasonLayout.Items.Count - 1; i >= 0; i++)
                seasonLayout.Items.RemoveAt(i);

            // Add seasons
            foreach (var season in seasons)
                seasonLayout.Items.Add(CreateSeasonButton(season));
        }

        private void UpdateChapterPanel(TSeasonData season)
        {
            var chapterPanel = GetChapterPanel(_rein,season);

            var items = mainLayout.Items;
            var item = new StackItem(chapterPanel) { Size = new Size(.65f, 1f) };

            if (items.Count < 2)
                items.Add(item);
            else
                items[1] = item;
        }

        private NierButton CreateSeasonButton(TSeasonData season)
        {
            var result = new NierButton
            {
                Caption = GetSeasonName(season),
                Active = CurrentSeason.Equals(season),
                IsClickActive = true,
                Width = 0.125f,
                Padding = new Vector2(0, 2)
            };
            result.Clicked += (s, e) => SeasonBtn_Clicked((NierButton)s, season);

            return result;
        }

        private void SeasonBtn_Clicked(NierButton sender, TSeasonData season)
        {
            foreach (var seasonBtn in seasonLayout.Items)
                (seasonBtn.Content as NierButton).Active = sender == seasonBtn.Content;

            CurrentSeason = season;
            UpdateChapterPanel(season);
        }
    }
}
