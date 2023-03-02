using ImGui.Forms.Controls;
using ImGui.Forms.Controls.Base;
using ImGui.Forms.Controls.Layouts;
using ImGui.Forms.Controls.Lists;
using NierReincarnation.App.Controls.Buttons;
using NierReincarnation.App.Resources;
using NierReincarnation.Context.Support;
using NierReincarnation.Core.Dark.Calculator;
using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Core.Dark.View.UserInterface.Text;
using NierReincarnation.Core.Subsystem.Calculator.Outgame;
using NierReincarnation.Core.UnityEngine;
using System;
using Color = System.Drawing.Color;
using Vector2 = System.Numerics.Vector2;

namespace NierReincarnation.App.Forms
{
    internal partial class MainForm
    {
        private StackLayout mainContent;
        private TableLayout headerLayout;

        private Label userLabel;
        private Label staminaLabel;
        private Label versionLabel;
        private Label cooldownLabel;

        private NierButton loadoutButton;
        private NierButton questsButton;
        private NierButton mapButton;

        //private IList<NierButton> btnList;

        private void InitializeComponent()
        {
            Title = LocalizationResources.Title;
            Icon = ImageResources.Icon;

            CooldownTimer.CooldownStart += CooldownTimer_CooldownStart;
            CooldownTimer.CooldownFinish += CooldownTimer_CooldownFinish;
            CooldownTimer.Elapsed += CooldownTimer_Elapsed;
        }

        private void SetMainContent()
        {
            userLabel = new Label
            {
                Text = GetUserString(),
                Font = FontResources.FotRodin(11)
            };
            staminaLabel = new Label
            {
                Text = GetStaminaString(),
                Font = FontResources.FotRodin(11)
            };
            versionLabel = new Label
            {
                Font = FontResources.FotRodin(11),
                Text = string.Format(LocalizationResources.GameVersion, Application.Version),
            };
            cooldownLabel = new Label
            {
                Font = FontResources.FotRodin(11),
                Text = GetCooldownString(TimeSpan.Zero),
                TextColor = Color.Firebrick,
                Visible = false
            };

            var staminaRefreshButton = new StaminaPreferenceButton();
            loadoutButton = new NierButton
            {
                Text = UserInterfaceTextKey.Footer.kLoadout.Localize(),
                Padding = new Vector2(0, 15),
                IsClickActive = true,

                Width = 125
            };
            questsButton = new NierButton
            {
                Text = UserInterfaceTextKey.Footer.kQuests.Localize(),
                Padding = new Vector2(0, 15),
                IsClickActive = true,

                Width = 125
            };
            mapButton = new NierButton
            {
                Text = UserInterfaceTextKey.Footer.kMap.Localize(),
                Padding = new Vector2(0, 15),
                IsClickActive = true,

                Width = 125
            };

            headerLayout = new TableLayout
            {
                Spacing = new Vector2(5, 5),
                Size = ImGui.Forms.Models.Size.Content,
                Rows =
                {
                    new TableRow
                    {
                        Cells =
                        {
                            userLabel,
                            new StackLayout
                            {
                                Alignment = Alignment.Horizontal,
                                HorizontalAlignment = HorizontalAlignment.Center,
                                Size = ImGui.Forms.Models.Size.WidthAlign,
                                ItemSpacing = 5,
                                Items =
                                {
                                    new StackItem(staminaLabel) {VerticalAlignment = VerticalAlignment.Center},
                                    staminaRefreshButton
                                }
                            },
                            versionLabel
                        }
                    },
                    new TableRow
                    {
                        Cells =
                        {
                            null,
                            null,
                            null
                        }
                    }
                }
            };

            Content = mainContent = new StackLayout
            {
                Alignment = Alignment.Vertical,
                ItemSpacing = 10,
                Items =
                {
                    // Header
                    headerLayout,

                    // Content
                    new StackItem(null) {Size = ImGui.Forms.Models.Size.Parent},

                    // Footer
                    new StackItem(new ActivableList
                    {
                        Alignment = Alignment.Horizontal,
                        Size = ImGui.Forms.Models.Size.Content,
                        ItemSpacing = 5,
                        Items =
                        {
                            loadoutButton,
                            questsButton,
                            mapButton
                        }
                    }){HorizontalAlignment = HorizontalAlignment.Center}
                }
            };
        }

        public void SetMenuContent(Panel comp)
        {
            subMenu = comp;
            mainContent.Items[1] = new StackItem(comp) { Size = ImGui.Forms.Models.Size.Parent };
        }

        public void UpdateUser()
        {
            userLabel.Text = GetUserString();
        }

        public void UpdateStamina()
        {
            staminaLabel.Text = GetStaminaString();
        }

        private static string GetUserString()
        {
            return $"{CalculatorProfile.GetName(CalculatorStateUser.GetUserId())} | {UserInterfaceTextKey.Header.kUserLevel.Localize()}: {CalculatorUserStatus.GetCurrentUserLevel()}";
        }

        private static string GetStaminaString()
        {
            return $"{UserInterfaceTextKey.Header.kStamina.Localize()} {CalculatorUserStatus.GetCurrentStamina()}/{CalculatorUserStatus.GetMaxStamina()}";
        }

        private static string GetCooldownString(TimeSpan time)
        {
            return string.Format(LocalizationResources.Cooldown, time);
        }

        #region Cooldown Events

        private void CooldownTimer_Elapsed(object sender, TimeSpan e)
        {
            cooldownLabel.Text = GetCooldownString(e);
        }

        private void CooldownTimer_CooldownFinish(object sender, EventArgs e)
        {
            SetCooldownLabel(null);

            cooldownLabel.Text = GetCooldownString(TimeSpan.Zero);
            cooldownLabel.Visible = false;
        }

        private void CooldownTimer_CooldownStart(object sender, TimeSpan e)
        {
            SetCooldownLabel(cooldownLabel);

            cooldownLabel.Text = GetCooldownString(e);
            cooldownLabel.Visible = true;
        }

        private void SetCooldownLabel(Component component)
        {
            if (component == null)
                headerLayout.Rows[1].Cells[1] = null;
            else
                headerLayout.Rows[1].Cells[1] = new TableCell(component) { Size = ImGui.Forms.Models.Size.WidthAlign, HorizontalAlignment = HorizontalAlignment.Center };
        }

        #endregion Cooldown Events
    }
}
