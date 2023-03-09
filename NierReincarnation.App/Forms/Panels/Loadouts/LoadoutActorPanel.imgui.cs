using ImGui.Forms.Controls;
using ImGui.Forms.Controls.Layouts;
using ImGui.Forms.Controls.Lists;
using ImGui.Forms.Models;
using NierReincarnation.App.Controls.Buttons.Items;
using NierReincarnation.App.Resources;
using System.Numerics;

namespace NierReincarnation.App.Forms.Panels.Loadouts
{
    internal partial class LoadoutActorPanel
    {
        private NierCostumeItemButton costumeButton;
        private NierCompanionItemButton companionButton;
        private NierThoughtItemButton thoughtButton;
        private NierWeaponItemButton mainWeaponButton;
        private NierWeaponItemButton subWeapon1Button;
        private NierWeaponItemButton subWeapon2Button;
        private NierMemoryItemButton memoir1Button;
        private NierMemoryItemButton memoir2Button;
        private NierMemoryItemButton memoir3Button;

        private void InitializeComponent()
        {
            costumeButton = new NierCostumeItemButton();
            companionButton = new NierCompanionItemButton();
            thoughtButton = new NierThoughtItemButton();
            mainWeaponButton = new NierWeaponItemButton();
            subWeapon1Button = new NierWeaponItemButton();
            subWeapon2Button = new NierWeaponItemButton();
            memoir1Button = new NierMemoryItemButton();
            memoir2Button = new NierMemoryItemButton();
            memoir3Button = new NierMemoryItemButton();

            Content = new List
            {
                ItemSpacing = 5,
                Items =
                {
                    costumeButton,
                    new Label
                    {
                        Text = LocalizationResources.DeckWeaponTitle
                    },
                    new StackLayout
                    {
                        Alignment = Alignment.Horizontal,
                        Size = Size.WidthAlign,
                        ItemSpacing = 5,
                        Items =
                        {
                            mainWeaponButton,
                            subWeapon1Button,
                            subWeapon2Button
                        }
                    },
                    new TableLayout
                    {
                        Size = Size.WidthAlign,
                        Spacing = new Vector2(5, 5),
                        Rows =
                        {
                            new TableRow
                            {
                                Cells =
                                {
                                    new TableCell(new Label
                                    {
                                        Text = LocalizationResources.DeckCompanionTitle
                                    })
                                    {
                                        Size = new Size(((int)NierResources.ItemSlotSize.X * 2) + 5, SizeValue.Content)
                                    },
                                    new Label
                                    {
                                        Text = LocalizationResources.DeckDebrisTitle
                                    }
                                }
                            },
                            new TableRow
                            {
                                Cells =
                                {
                                    new TableCell(companionButton)
                                    {
                                        Size = new Size(((int)NierResources.ItemSlotSize.X * 2) + 5, SizeValue.Content)
                                    },
                                    thoughtButton
                                }
                            }
                        }
                    },
                    new Label
                    {
                        Text = LocalizationResources.DeckMemoirTitle
                    },
                    new StackLayout
                    {
                        Alignment = Alignment.Horizontal,
                        Size = Size.WidthAlign,
                        ItemSpacing = 5,
                        Items =
                        {
                            memoir1Button,
                            memoir2Button,
                            memoir3Button
                        }
                    }
                }
            };
        }
    }
}
