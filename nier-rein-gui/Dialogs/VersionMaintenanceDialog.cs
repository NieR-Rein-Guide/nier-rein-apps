using System.Numerics;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ImGui.Forms;
using ImGui.Forms.Controls;
using ImGui.Forms.Controls.Layouts;
using ImGui.Forms.Modals;
using ImGui.Forms.Modals.IO;
using nier_rein_gui.Properties;
using nier_rein_gui.Resources;
using Size = ImGui.Forms.Models.Size;

namespace nier_rein_gui.Dialogs
{
    class VersionMaintenanceDialog : Modal
    {
        private static readonly Regex VersionPattern = new Regex(@"\d+\.\d+\.\d+");

        public VersionMaintenanceDialog()
        {
            var warningLabel = new Label { Text = LocalizationResources.VersionMaintenanceWarning };
            var secondWarningLabel = new Label { Text = string.Format(LocalizationResources.VersionMaintenanceManualWarning, NierReincarnation.Core.UnityEngine.Application.Version) };
            var versionButton = new Button { Text = LocalizationResources.VersionMaintenanceChangeVersion, Width = 130 };
            var quitButton = new Button { Text = LocalizationResources.VersionMaintenanceQuit, Width = 50 };

            Size = new Vector2(500, 80);
            Caption = LocalizationResources.VersionMaintenanceTitle;
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
                        Size = ImGui.Forms.Models.Size.WidthAlign,
                        ItemSpacing = 5,
                        Alignment = Alignment.Horizontal,
                        Items =
                        {
                            versionButton,
                            new StackItem(quitButton){Size = ImGui.Forms.Models.Size.WidthAlign,HorizontalAlignment = HorizontalAlignment.Right}
                        }
                    }
                }
            };

            versionButton.Clicked += VersionButton_Clicked;
            quitButton.Clicked += QuitButton_Clicked;
        }

        private async void VersionButton_Clicked(object sender, System.EventArgs e)
        {
            var newVersion = await InputBox.ShowAsync(
                LocalizationResources.VersionMaintenanceChangeVersionTitle,
                LocalizationResources.VersionMaintenanceChangeVersionDescription,
                NierReincarnation.Core.UnityEngine.Application.Version,
                LocalizationResources.VersionMaintenanceChangeVersionPlaceholder);
            if (newVersion == null)
                return;

            if (!VersionPattern.IsMatch(newVersion))
            {
                await MessageBox.ShowErrorAsync(LocalizationResources.VersionMaintenanceChangeVersionErrorTitle, 
                    string.Format(LocalizationResources.VersionMaintenanceChangeVersionErrorDescription, newVersion));
                return;
            }

            NierReincarnation.Core.UnityEngine.Application.Version = newVersion;

            Settings.Default.AppVersion = newVersion;
            Settings.Default.Save();
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