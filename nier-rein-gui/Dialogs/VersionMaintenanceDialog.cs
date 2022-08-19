using System.Drawing;
using System.Numerics;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ImGui.Forms;
using ImGui.Forms.Controls;
using ImGui.Forms.Controls.Layouts;
using ImGui.Forms.Modals;
using ImGui.Forms.Modals.IO;
using nier_rein_gui.Properties;
using Size = ImGui.Forms.Models.Size;

namespace nier_rein_gui.Dialogs
{
    class VersionMaintenanceDialog : Modal
    {
        private static readonly Regex VersionPattern = new Regex(@"\d+\.\d+\.\d+");

        public VersionMaintenanceDialog()
        {
            var warningLabel = new Label { Caption = "There is either a new game version or a maintenance." };
            var secondWarningLabel = new Label { Caption = $"Manually change the current game version ({NierReincarnation.Core.UnityEngine.Application.Version}) before restarting the app,\nif a new game version released!" };
            var versionButton = new Button { Caption = "Change version", Width = 130 };
            var quitButton = new Button { Caption = "Quit", Width = 50 };

            Size = new Vector2(500, 80);
            Caption = "Maintenance/Version update";
            Content = new StackLayout
            {
                ItemSpacing = 5,
                Alignment = Alignment.Vertical,
                Items =
                {
                    new StackLayout
                    {
                        Alignment = Alignment.Vertical,
                        ItemSpacing = 5,
                        Items =
                        {
                            warningLabel,
                            secondWarningLabel,
                        }
                    },
                    new StackLayout
                    {
                        Size = new Size(1f,-1),
                        ItemSpacing = 5,
                        Alignment = Alignment.Horizontal,
                        Items =
                        {
                            versionButton,
                            new StackItem(quitButton){Size = new Size(1f,-1),HorizontalAlignment = HorizontalAlignment.Right}
                        }
                    }
                }
            };

            versionButton.Clicked += VersionButton_Clicked;
            quitButton.Clicked += QuitButton_Clicked;
        }

        private async void VersionButton_Clicked(object sender, System.EventArgs e)
        {
            var newVersion = await InputBox.ShowAsync("Change game version", "Game version", NierReincarnation.Core.UnityEngine.Application.Version, "Version e.g. 2.11.0");
            if (newVersion != null)
            {
                if (!VersionPattern.IsMatch(newVersion))
                {
                    await MessageBox.ShowErrorAsync("Wrong version pattern", $"The entered version \"{newVersion}\" is not correct.");
                    return;
                }

                NierReincarnation.Core.UnityEngine.Application.Version = newVersion;

                Settings.Default.AppVersion = newVersion;
                Settings.Default.Save();
            }
        }

        private void QuitButton_Clicked(object sender, System.EventArgs e)
        {
            Close(DialogResult.Cancel);
        }

        protected override Task CloseInternal()
        {
            Application.Instance.Exit();

            return Task.CompletedTask;
        }
    }
}
