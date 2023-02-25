using System.Collections.Generic;
using System.Numerics;
using ImGui.Forms.Controls.Layouts;
using ImGui.Forms.Controls.Lists;
using ImGui.Forms.Models;
using nier_rein_gui.Controls.Buttons;

namespace nier_rein_gui.Forms.Panels.SubQuests.Base
{
    abstract partial class SeasonPanel<TSeasonData>
    {
        private StackLayout mainLayout;
        private ActivableList seasonList;

        protected TSeasonData CurrentSeason { get; set; }

        private void InitializeComponent()
        {
            seasonList = new ActivableList
            {
                Alignment = Alignment.Horizontal,
                ItemSpacing = 5,
                Size = Size.WidthAlign
            };

            Content = mainLayout = new StackLayout
            {
                Alignment = Alignment.Vertical,
                ItemSpacing = 5,
                Items =
                {
                    seasonList,
                    new StackItem(null)
                }
            };

            UpdateLayout(mainLayout);
        }

        protected virtual void UpdateLayout(StackLayout layout) { }

        private void UpdateSeasonList(IList<TSeasonData> seasons)
        {
            CurrentSeason = seasons[0];

            // Clear layout
            seasonList.Items.Clear();

            // Add seasons
            foreach (var season in seasons)
                seasonList.Items.Add(CreateSeasonButton(season));
        }

        protected void UpdateChapterPanel(TSeasonData season)
        {
            var chapterPanel = GetChapterPanel(_rein, season);

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
                Text = GetSeasonName(season),
                Active = CurrentSeason.Equals(season),
                IsClickActive = true,
                Width = 120,
                Padding = new Vector2(0, 2)
            };
            result.Clicked += (s, e) => SeasonBtn_Clicked(season);

            return result;
        }

        private void SeasonBtn_Clicked(TSeasonData season)
        {
            CurrentSeason = season;
            UpdateChapterPanel(season);
        }
    }
}
