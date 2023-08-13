using ImGui.Forms;
using ImGui.Forms.Controls;
using ImGui.Forms.Modals;
using NierReincarnation.App.Dialogs;
using NierReincarnation.App.Forms.Panels;
using NierReincarnation.App.Forms.Panels.Loadouts;
using NierReincarnation.App.Properties;
using NierReincarnation.Context;
using System;
using System.Threading.Tasks;
using Application = NierReincarnation.Core.UnityEngine.Application;

namespace NierReincarnation.App.Forms
{
    internal partial class MainForm : Form
    {
        private NierReinContexts _rein;

        private Panel subMenu;

        public MainForm()
        {
            InitializeComponent();

            Load += MainForm_Load;
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            // Set app version
            if (!string.IsNullOrEmpty(Settings.Default.AppVersion))
                Application.Version = Settings.Default.AppVersion;

            if (VersionChecker.CanDetermine(Application.Language))
            {
                var currentVersion = VersionChecker.GetCurrentVersion(Application.Language);
                if (Application.Version != currentVersion)
                {
                    Application.Version = Settings.Default.AppVersion = currentVersion;
                    Settings.Default.Save();
                }
            }

            // Set stamina preference
            if (Settings.Default.StaminaPreference != null)
                StaminaContext.SetPreferences(Settings.Default.StaminaPreference);

            // Ensure application being setup
            var isInitialized = await EnsureApplication();
            if (!isInitialized)
                return;

            _rein = NierReincarnation.GetContexts();

            // Check if a quest is still running
            await EnsureNoRunningQuest();

            // Initialize main content
            SetMainContent();

            // Initialize events
            questsButton.Clicked += QuestsButtonClicked;
            loadoutButton.Clicked += LoadoutButton_Clicked;
            mapButton.Clicked += MapButton_Clicked;
        }

        private async Task<bool> EnsureApplication()
        {
            var setupAppDlg = new SetupApplicationDialog();

            var result = await setupAppDlg.ShowAsync();
            if (result == DialogResult.Ok)
                return true;

            Close();

            return false;
        }

        private Task EnsureNoRunningQuest()
        {
            if (!BattleContext.HasRunningQuest())
                return Task.CompletedTask;

            var dlg = new ResumeFlowDialog(_rein);
            return dlg.ShowAsync();
        }

        private void LoadoutButton_Clicked(object sender, EventArgs e)
        {
            if (subMenu is LoadoutPanel)
                return;

            SetMenuContent(new LoadoutPanel(_rein, this));
        }

        private void QuestsButtonClicked(object sender, EventArgs e)
        {
            if (subMenu is SubQuestPanel)
                return;

            SetMenuContent(new SubQuestPanel(_rein, this));
        }

        private void MapButton_Clicked(object sender, EventArgs e)
        {
            if (subMenu is MapSeasonPanel)
                return;

            SetMenuContent(new MapSeasonPanel(_rein, this));
        }
    }
}
