using System.Numerics;
using ImGui.Forms.Controls;
using ImGui.Forms.Controls.Layouts;
using ImGui.Forms.Controls.Lists;
using ImGui.Forms.Models;
using nier_rein_gui.Controls;
using nier_rein_gui.Resources;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Core.Dark.View.UserInterface;
using NierReincarnation.Core.Dark.View.UserInterface.Text;

namespace nier_rein_gui.Forms.SubForms
{
    abstract partial class QuestPanel
    {
        private NierButton difficultyButton;

        private void InitializeComponent(EventQuestChapterData chapter)
        {
            if (chapter.EventQuestChapterDifficultyTypes.Count > 1)
                difficultyButton = new NierButton { Caption = string.Format(UserInterfaceTextKey.Quest.kQuestDifficulty, (int)chapter.EventQuestChapterDifficultyTypes[0]).Localize(), Width = 100 };

            Content = new StackLayout
            {
                Alignment = Alignment.Vertical,
                ItemSpacing = 5,
                Items =
                {
                    new StackLayout
                    {
                        Alignment = Alignment.Horizontal,
                        Size = new Size(1f, -1),
                        Items =
                        {
                            new StackItem(new Label {Caption = chapter.EventQuestName}){VerticalAlignment = VerticalAlignment.Center},
                            new StackItem(difficultyButton) {Size = new Size(1f, -1), HorizontalAlignment = HorizontalAlignment.Right}
                        }
                    },
                    new StackItem(null)
                }
            };
        }

        protected void SetQuestList(EventQuestChapterData chapter, DifficultyType type)
        {
            var btnList = new List
            {
                ItemSpacing = 5
            };

            foreach (var quest in GetChapterQuests(chapter, type))
            {
                var btn = new NierQuestButton
                {
                    Padding = new Vector2(2, 2),
                    SubFont = FontResources.FotRodin(12),
                    DailyFont = FontResources.FotRodin(9),
                    ClearFont = FontResources.FotRodin(11),
                    Caption = quest.QuestName,
                    Stamina = quest.Quest.EntityQuest.Stamina,
                    SuggestedPower = quest.RecommendPower,
                    IsClear = quest.IsClearQuest,
                    Enabled = !quest.IsLock,
                    IsDaily = quest.Quest.EntityQuest.DailyClearableCount > 0
                };
                btn.Clicked += async (s, e) => await FightAsync(chapter, type, quest);

                btnList.Items.Add(btn);
            }

            (Content as StackLayout).Items[1] = new StackItem(btnList);
        }
    }
}
