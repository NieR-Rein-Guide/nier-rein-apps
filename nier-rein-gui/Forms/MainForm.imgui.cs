using System.Collections.Generic;
using ImGui.Forms.Controls;
using ImGui.Forms.Controls.Layouts;
using ImGui.Forms.Models;
using nier_rein_gui.Controls;
using nier_rein_gui.Controls.Buttons;
using nier_rein_gui.Resources;
using NierReincarnation.Core.Dark.Calculator;
using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Core.Dark.View.UserInterface.Text;
using NierReincarnation.Core.Subsystem.Calculator.Outgame;
using NierReincarnation.Core.UnityEngine;
using Vector2 = System.Numerics.Vector2;

namespace nier_rein_gui.Forms
{
    partial class MainForm
    {
        private StackLayout mainContent;

        private Label userLabel;
        private Label staminaLabel;
        private Label versionLabel;

        private NierButton loadoutButton;
        private NierButton questsButton;

        private IList<NierButton> btnList;

        private void InitializeComponent()
        {
            Title = "Nier Reincarnation EX";
            Icon = ImageResources.Icon;
        }

        private void SetMainContent()
        {
            userLabel = new Label
            {
                Caption = GetUserString(),
                Font = FontResources.FotRodin(11)
            };
            staminaLabel = new Label
            {
                Caption = GetStaminaString(),
                Font = FontResources.FotRodin(11)
            };
            versionLabel = new Label
            {
                Font = FontResources.FotRodin(11),
                Caption = $"Game version: {Application.Version}"
            };

            var staminaRefreshButton = new StaminaPreferenceButton();
            loadoutButton = new NierButton
            {
                Caption = UserInterfaceTextKey.Footer.kLoadout.Localize(),
                Padding = new Vector2(0, 15),
                IsClickActive = true,

                Width = .15f
            };
            questsButton = new NierButton
            {
                Caption = UserInterfaceTextKey.Footer.kQuests.Localize(),
                Padding = new Vector2(0, 15),
                IsClickActive = true,

                Width = .15f
            };

            btnList = new List<NierButton>
            {
                loadoutButton,
                questsButton
            };

            Content = mainContent = new StackLayout
            {
                Alignment = Alignment.Vertical,
                ItemSpacing = 10,
                Items =
                {
                    // Header
                    new StackLayout
                    {
                        Alignment = Alignment.Horizontal,
                        ItemSpacing = 5,
                        Size = new Size(1f,-1),
                        Items =
                        {
                            userLabel,
                            new StackLayout
                            {
                                Alignment = Alignment.Horizontal,
                                HorizontalAlignment = HorizontalAlignment.Center,
                                Size = new Size(1f,-1),
                                ItemSpacing = 5,
                                Items =
                                {
                                    new StackItem(staminaLabel){VerticalAlignment = VerticalAlignment.Center},
                                    staminaRefreshButton
                                }
                            },
                            //new StackItem(staminaLabel){ Size = new Size(1f, -1), HorizontalAlignment = HorizontalAlignment.Center},
                            versionLabel
                        }
                    },

                    // Content
                    new StackItem(null) {Size = ImGui.Forms.Models.Size.Parent},

                    // Footer
                    new StackLayout
                    {
                        Alignment = Alignment.Horizontal,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center,
                        Size = new Size(1f, -1),
                        ItemSpacing = 10,
                        Items =
                        {
                            loadoutButton,
                            questsButton
                        }
                    }
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
            userLabel.Caption = GetUserString();
        }

        public void UpdateStamina()
        {
            staminaLabel.Caption = GetStaminaString();
        }

        private string GetUserString()
        {
            return $"{CalculatorProfile.GetName(CalculatorStateUser.GetUserId())} | {UserInterfaceTextKey.Header.kUserLevel.Localize()}: {CalculatorUserStatus.GetCurrentUserLevel()}";
        }

        private string GetStaminaString()
        {
            return $"{UserInterfaceTextKey.Header.kStamina.Localize()} {CalculatorUserStatus.GetCurrentStamina()}/{CalculatorUserStatus.GetMaxStamina()}";
        }
    }
}
