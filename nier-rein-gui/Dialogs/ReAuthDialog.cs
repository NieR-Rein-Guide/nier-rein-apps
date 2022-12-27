using ImGui.Forms.Controls;
using ImGui.Forms.Controls.Layouts;
using ImGui.Forms.Modals;
using nier_rein_gui.Resources;

namespace nier_rein_gui.Dialogs
{
    class ReAuthDialog : Modal
    {
        public bool KeepOpen { get; set; } = true;

        public ReAuthDialog()
        {
            Caption = LocalizationResources.AuthTitle;
            Content = new StackLayout
            {
                Alignment = Alignment.Vertical,
                Items =
                {
                    new StackItem(new Label {Caption = LocalizationResources.AuthDescription})
                    {
                        VerticalAlignment = VerticalAlignment.Center,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        Size = ImGui.Forms.Models.Size.Parent
                    }
                }
            };
        }

        protected override bool ShouldCancelClose()
        {
            return KeepOpen;
        }
    }
}
