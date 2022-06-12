using System.Numerics;
using ImGui.Forms.Controls.Layouts;
using ImGui.Forms.Models;
using nier_rein_gui.Controls;
using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Core.Dark.View.UserInterface.Text;

namespace nier_rein_gui.Forms.SubForms
{
    partial class SubQuestPanel
    {
        private NierButton mainQuestButton;
        private NierButton subQuestButton;
        private NierButton bigHuntButton;
        private NierButton explorationButton;

        private void InitializeComponent()
        {
            mainQuestButton = new NierButton { Caption = UserInterfaceTextKey.Quest.kMainQuest.Localize(), Width = .5f, Padding = new Vector2(0, 5) };
            subQuestButton = new NierButton { Caption = UserInterfaceTextKey.Quest.kEventQuestTitle.Localize(), Width = .5f, Padding = new Vector2(0, 5) };
            bigHuntButton = new NierButton { Caption = UserInterfaceTextKey.Quest.kBigHuntQuest.Localize(), Width = .5f, Padding = new Vector2(0, 5) };
            explorationButton = new NierButton { Caption = UserInterfaceTextKey.Quest.kSearch.Localize(), Width = .5f, Padding = new Vector2(0, 5), Enabled = false };

            Content = new StackLayout
            {
                Alignment = Alignment.Vertical,
                HorizontalAlignment = HorizontalAlignment.Center,
                Size = new Size(-1, 1f),
                ItemSpacing = 5,
                Items =
                {
                    mainQuestButton,
                    subQuestButton,
                    bigHuntButton,
                    explorationButton
                }
            };
        }
    }
}
