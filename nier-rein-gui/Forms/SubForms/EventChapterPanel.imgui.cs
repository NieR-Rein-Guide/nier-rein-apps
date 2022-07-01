using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using ImGui.Forms.Controls;
using ImGui.Forms.Controls.Base;
using ImGui.Forms.Controls.Layouts;
using ImGui.Forms.Controls.Lists;
using ImGui.Forms.Models;
using nier_rein_gui.Controls;
using nier_rein_gui.Controls.Buttons;
using nier_rein_gui.Resources;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Core.Dark.View.UserInterface;
using NierReincarnation.Core.Dark.View.UserInterface.Text;

namespace nier_rein_gui.Forms.SubForms
{
    // EventChapter UI code
    partial class EventChapterPanel
    {
        private StackLayout mainContent;

        private NierButton characterQuestButton;
        private NierButton darkMemoryButton;

        private IList<(NierButton, EventQuestChapterData)> eventButtons;

        private void InitializeComponent()
        {
            characterQuestButton = new NierButton
            {
                Padding = new Vector2(0, 5),
                Width = 1f,
                Caption = UserInterfaceTextKey.Quest.kEventQuestCharacter.Localize(),
                IsClickActive = true,
                Enabled = false
            };
            darkMemoryButton = new NierButton
            {
                Padding = new Vector2(0, 5),
                Width = 1f,
                Caption = UserInterfaceTextKey.Quest.kEventQuestEndContents.Localize(),
                IsClickActive = true
            };

            eventButtons = new List<(NierButton, EventQuestChapterData)>();
            var btnList = CreateButtonList();

            Content = mainContent = new StackLayout
            {
                Alignment = Alignment.Vertical,
                ItemSpacing = 5,
                Items =
                {
                    new Label
                    {
                        Caption = UserInterfaceTextKey.Header.kQuestEvent.Localize(),
                        Font = FontResources.FotRodin(20)
                    },
                    new StackLayout
                    {
                        Alignment = Alignment.Horizontal,
                        ItemSpacing = 10,
                        Items =
                        {
                            new StackItem(new List
                            {
                                ItemSpacing = 5,
                                Items = btnList
                            }) {Size = new Size(.35f, 1f)},
                            null
                        }
                    }
                }
            };
            SetMenuContent(null);
        }

        private IList<Component> CreateButtonList()
        {
            var result = new List<Component>();

            foreach (var chapter in GetEventChapters())
            {
                var btn = new NierButton
                {
                    Padding = new Vector2(0, 5),
                    Width = 1f,
                    Caption = chapter.EventQuestName,
                    IsClickActive = true,
                    Enabled = chapter.EventQuestType != EventQuestType.DUNGEON
                };

                eventButtons.Add((btn, chapter));
                result.Add(btn);
            }

            result.Add(characterQuestButton);
            result.Add(darkMemoryButton);

            return result;
        }

        private void SetMenuContent(Component comp)
        {
            (mainContent.Items[1].Content as StackLayout).Items[1] = new StackItem(comp) { Size = new Size(.7f, 1f) };
        }
    }
}
