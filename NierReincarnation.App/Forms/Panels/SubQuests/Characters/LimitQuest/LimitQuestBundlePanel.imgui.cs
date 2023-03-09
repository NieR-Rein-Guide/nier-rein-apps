using ImGui.Forms.Controls;
using ImGui.Forms.Controls.Layouts;
using ImGui.Forms.Controls.Lists;
using ImGui.Forms.Models;
using ImGuiNET;
using NierReincarnation.App.Controls.Buttons;
using NierReincarnation.App.Resources;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Core.Dark.View.UserInterface.Outgame;
using NierReincarnation.Core.Dark.View.UserInterface.Text;
using System.Collections.Generic;

namespace NierReincarnation.App.Forms.Panels.SubQuests.Characters.LimitQuest
{
    internal partial class LimitQuestBundlePanel
    {
        private StackLayout mainLayout;

        private Label nameLabel;

        private NierButton difficultyBtn;

        private ArrowButton backBtn;
        private ArrowButton prevBtn;
        private ArrowButton nextBtn;

        private List bundleList;

        private void InitializeComponent(string name, IList<DifficultyType> difficulties)
        {
            difficultyBtn = new NierButton { Text = string.Format(UserInterfaceTextKey.Quest.kQuestDifficulty, (int)difficulties[0]).Localize(), Width = 100 };

            backBtn = new ArrowButton { Direction = ImGuiDir.Left };
            prevBtn = new ArrowButton { Direction = ImGuiDir.Left };
            nextBtn = new ArrowButton { Direction = ImGuiDir.Right };

            bundleList = new List { ItemSpacing = 5, Size = Size.Parent };

            Content = mainLayout = new StackLayout
            {
                Alignment = Alignment.Vertical,
                ItemSpacing = 5,
                Items =
                {
                    CreateHeaderLayout(name),
                    new StackLayout
                    {
                        Alignment = Alignment.Horizontal,
                        ItemSpacing=5,
                        Items=
                        {
                            new StackItem(prevBtn){VerticalAlignment = VerticalAlignment.Center},
                            bundleList,
                            new StackItem(nextBtn){VerticalAlignment = VerticalAlignment.Center},
                        }
                    }
                }
            };
        }

        private StackLayout CreateHeaderLayout(string name)
        {
            var layout = new StackLayout
            {
                Alignment = Alignment.Horizontal,
                ItemSpacing = 5,
                Size = Size.WidthAlign,
                Items =
                {
                    backBtn
                }
            };

            if (!string.IsNullOrEmpty(name))
            {
                nameLabel = new Label { Text = name, Font = FontResources.FotRodin(20) };
                layout.Items.Add(nameLabel);
            }

            if (difficultyBtn != null)
                layout.Items.Add(new StackItem(difficultyBtn) { Size = Size.WidthAlign, HorizontalAlignment = HorizontalAlignment.Right });

            return layout;
        }

        protected void UpdateName(string name)
        {
            if (nameLabel != null)
                nameLabel.Text = name;
        }

        private void UpdateDifficultyText(DifficultyType difficulty)
        {
            difficultyBtn.Text = string.Format(UserInterfaceTextKey.Quest.kQuestDifficulty, (int)difficulty).Localize();
        }

        // TODO: Use correct button type
        private void UpdateQuestBundleList(DataLimitContentCharacter chapter, DifficultyType difficulty)
        {
            bundleList.Items.Clear();

            var levels = CalculatorLimitContent.CreateDataLimitContentLevels(chapter.EventQuestLimitContentId, difficulty);
            foreach (var level in levels)
            {
                var levelButton = new LimitContentBundleButton
                {
                    Bundle = level,
                    Caption = $"{level.LevelName}",
                    Width = 1f,
                    Enabled = !level.IsLock
                };
                levelButton.Clicked += (s, e) =>
                {
                    var panel = new LimitQuestListPanel(_rein, level.LevelName, CalculatorQuest.GenerateEventQuestData(level.EventQuestChapterId, difficulty), difficulty);
                    panel.Closed += Panel_Closed;

                    Content = panel;
                };

                bundleList.Items.Add(levelButton);
            }

            Content = mainLayout;
        }

        private void Panel_Closed(object sender, System.EventArgs e)
        {
            UpdateQuestBundleList(_currentChapter, CurrentDifficulty);
        }
    }
}
