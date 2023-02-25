using ImGui.Forms.Controls;
using ImGui.Forms.Controls.Layouts;
using ImGui.Forms.Models;

namespace nier_rein_gui.Forms.Panels.SubQuests.Quests.Base
{
    partial class GuerrillaQuestPanel
    {
        private Label timeLabel;
        private Panel timePanel;

        private void InitializeComponent()
        {
            timeLabel = new Label();
            timePanel = new Panel
            {
                Content = new StackLayout
                {
                    Alignment = Alignment.Vertical,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    Size = Size.Content,
                    ItemSpacing = 5,
                    Items =
                    {
                        timeLabel
                    }
                }
            };
        }

        private void UpdateTimeTable(string timeTable)
        {
            timeLabel.Text = timeTable;
        }
    }
}
