﻿using System;
using System.Threading.Tasks;
using ImGui.Forms;
using ImGui.Forms.Controls;
using ImGui.Forms.Modals;
using nier_rein_gui.Dialogs;
using nier_rein_gui.Forms.SubForms;
using nier_rein_gui.Properties;
using NierReincarnation;
using NierReincarnation.Context;
using Application = NierReincarnation.Core.UnityEngine.Application;

namespace nier_rein_gui.Forms
{
    partial class MainForm : Form
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

            // Ensure application being setup
            var isInitialized = await EnsureApplication();
            if (!isInitialized)
                return;

            _rein = NierReincarnation.NierReincarnation.GetContexts();

            // Check if a quest is still running
            await EnsureNoRunningQuest();

            // Initialize main content
            SetMainContent();

            // Initialize events
            questsButton.Clicked += QuestsButtonClicked;
            loadoutButton.Clicked += LoadoutButton_Clicked;
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

            foreach (var btn in btnList)
                btn.Active = btn == sender;

            SetMenuContent(new LoadoutPanel(_rein, this));
        }

        private void QuestsButtonClicked(object sender, EventArgs e)
        {
            if (subMenu is SubQuestPanel)
                return;

            foreach (var btn in btnList)
                btn.Active = btn == sender;

            SetMenuContent(new SubQuestPanel(_rein, this));
        }

        private static ReauthDialog _reauthDlg;

        internal static async void BaseContext_BeforeUnauthenticated(object sender, EventArgs e)
        {
            _reauthDlg ??= new ReauthDialog();

            await _reauthDlg.ShowAsync();
        }

        internal static void BaseContext_AfterUnauthenticated(object sender, bool e)
        {
            if (_reauthDlg == null) 
                return;

            _reauthDlg.KeepOpen = false;

            _reauthDlg.Close(DialogResult.Ok);
            _reauthDlg = null;
        }

        class ReauthDialog : Modal
        {
            public bool KeepOpen { get; set; } = true;

            public ReauthDialog()
            {
                Content=new Label{Caption = "Initialize data..."};
            }

            protected override bool ShouldCancelClose()
            {
                return KeepOpen;
            }
        }
    }
}
