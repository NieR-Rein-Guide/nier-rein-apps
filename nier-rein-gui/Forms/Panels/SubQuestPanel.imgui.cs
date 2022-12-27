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
        private NierButton explorationButton;

        private void InitializeComponent()
        {
            mainQuestButton = new NierButton { Caption = UserInterfaceTextKey.Quest.kMainQuest.Localize(), Width = .3f, Padding = new Vector2(0, 5) };
            subQuestButton = new NierButton { Caption = UserInterfaceTextKey.Quest.kEventQuestTitle.Localize(), Width = .3f, Padding = new Vector2(0, 5) };
            exQuestButton = new NierButton { Caption = UserInterfaceTextKey.Quest.kExQuestTitle.Localize(), Width = .3f, Padding = new Vector2(0, 5) };
            bigHuntButton = new NierButton { Caption = UserInterfaceTextKey.Quest.kBigHuntQuest.Localize(), Width = .3f, Padding = new Vector2(0, 5) };
            explorationButton = new NierButton { Caption = UserInterfaceTextKey.Quest.kSearch.Localize(), Width = .3f, Padding = new Vector2(0, 5), Enabled = false };

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
                    },
                    new TableRow
                    {
                        Cells =
                        {
                            explorationButton
                        }
                    }
                }
            };
        }
    }
}
