using ImGui.Forms.Controls;
using ImGui.Forms.Controls.Layouts;
using ImGui.Forms.Modals;

namespace nier_rein_gui.Dialogs
{
    class ReAuthDialog : Modal
    {
        public bool KeepOpen { get; set; } = true;

        public ReAuthDialog()
        {
            Caption = "Re-Authorization";
            Content = new StackLayout
            {
                Alignment = Alignment.Vertical,
                Items =
                {
                    new StackItem(new Label {Caption = "Initialize data..."})
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
