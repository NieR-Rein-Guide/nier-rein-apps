using ImGui.Forms.Controls;
using ImGui.Forms.Controls.Layouts;
using ImGui.Forms.Controls.Lists;
using nier_rein_gui.Controls.Buttons.Items;
using nier_rein_gui.Resources;

namespace nier_rein_gui.Forms.SubForms
{
    partial class LoadoutActorPanel
    {
        private NierCostumeItemButton costumeButton;
        private NierCompanionItemButton companionButton;
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
                    new Label{Caption = "Weapons"},
                    mainWeaponButton,
                    new StackLayout
                    {
                        Alignment = Alignment.Horizontal,
                        ItemSpacing = 5,
                        Items =
                        {
                            subWeapon1Button,
                            subWeapon2Button
                        }
                    },
                    new Label{Caption = "Companion"},
                    companionButton,
                    new Label{Caption = "Memoirs"},
                    memoir1Button,
                    new StackLayout
                    {
                        Alignment = Alignment.Horizontal,
                        ItemSpacing = 5,
                        Items =
                        {
                            memoir2Button,
                            memoir3Button
                        }
                    }
                }
            };
        }
    }
}
