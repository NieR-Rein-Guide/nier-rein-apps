using System.Numerics;
using ImGui.Forms.Controls.Layouts;
using ImGui.Forms.Models;
using nier_rein_gui.Controls;
using nier_rein_gui.Controls.Buttons;
using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Core.Dark.View.UserInterface.Text;

namespace nier_rein_gui.Forms.Panels
{
    partial class SubQuestPanel
    {
        private NierButton mainQuestButton;
        private NierButton subQuestButton;
        private NierButton exQuestButton;
        private NierButton bigHuntButton;

        private void InitializeComponent()
        {
            mainQuestButton = new NierButton { Text = UserInterfaceTextKey.Quest.kMainQuest.Localize(), Width = .3f, Padding = new Vector2(0, 5) };
            subQuestButton = new NierButton { Text = UserInterfaceTextKey.Quest.kEventQuestTitle.Localize(), Width = .3f, Padding = new Vector2(0, 5) };
            exQuestButton = new NierButton { Text = UserInterfaceTextKey.Quest.kExQuestTitle.Localize(), Width = .3f, Padding = new Vector2(0, 5) };
            bigHuntButton = new NierButton { Text = UserInterfaceTextKey.Quest.kBigHuntQuest.Localize(), Width = .3f, Padding = new Vector2(0, 5) };

            Content = new TableLayout
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                Size = Size.HeightAlign,
                Spacing = new Vector2(5, 5),
                Rows =
                {
                    new TableRow
                    {
                        Cells =
                        {
                            mainQuestButton,
                            subQuestButton
                        }
                    },
                    new TableRow
                    {
                        Cells =
                        {
                            exQuestButton,
                            bigHuntButton
                        }
                    }
                }
            };
        }
    }
}
