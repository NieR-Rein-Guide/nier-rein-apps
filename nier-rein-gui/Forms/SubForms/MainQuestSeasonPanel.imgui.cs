using System.Collections.Generic;
using System.Numerics;
using ImGui.Forms.Controls.Layouts;
using ImGui.Forms.Controls.Lists;
using ImGui.Forms.Models;
using nier_rein_gui.Controls;

namespace nier_rein_gui.Forms.SubForms
{
    partial class MainQuestPanel
    {
        private List<NierButton> seasonButtonList;
        private List<NierButton> chapterButtonList;

        private void InitializeComponent()
        {
            seasonButtonList = new List<NierButton>();
            chapterButtonList = new List<NierButton>();

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
                            new StackItem(null)
                        }
                    }
                }
            };

            SetChapterList(CreateChapterButtonList());
        }

        private StackLayout CreateSeasonButtonLayout()
        {
            var result = new StackLayout
            {
                Alignment = Alignment.Horizontal,
                ItemSpacing = 5,
                Size = new Size(1f, -1)
            };

            // TODO: Set Enabled based on user status for story progress
            seasonButtonList.Clear();

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
                    Caption = chapter.MainQuestChapterName,
                    Active = chapters[0] == chapter,
                    IsClickActive = true,
                    Width = 0.2f,
                    Padding = new Vector2(0, 2)
                };

                chapterButtonList.Add(chapterBtn);
                result.Items.Add(chapterBtn);
            }

            return result;
        }
        
        private void SetChapterList(List chapterList)
        {
            ((Content as StackLayout).Items[1].Content as StackLayout).Items[0] = new StackItem(chapterList) { Size = new Size(.35f, 1f) };
        }
    }
}
