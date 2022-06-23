using ImGui.Forms.Controls;
using ImGui.Forms.Controls.Layouts;
using ImGui.Forms.Controls.Lists;
using nier_rein_gui.Controls.Buttons.Items;

namespace nier_rein_gui.Forms.SubForms
{
    partial class LoadoutActorPanel
    {
        private NierCostumeItemButton costumeButton;
        private NierCompanionItemButton companionButton;
        private NierWeaponItemButton mainWeaponButton;
        private NierWeaponItemButton subWeapon1Button;
        private NierWeaponItemButton subWeapon2Button;
        //private NierIconButton memoir1Button;
        //private NierIconButton memoir2Button;
        //private NierIconButton memoir3Button;

        private void InitializeComponent()
        {
            costumeButton = new NierCostumeItemButton();
            companionButton = new NierCompanionItemButton();
            mainWeaponButton = new NierWeaponItemButton();
            subWeapon1Button = new NierWeaponItemButton();
            subWeapon2Button = new NierWeaponItemButton();
            //memoir1Button = new NierIconButton { EmptySize = NierResources.ItemSlotSize };
            //memoir2Button = new NierIconButton { EmptySize = NierResources.ItemSlotSize };
            //memoir3Button = new NierIconButton { EmptySize = NierResources.ItemSlotSize };

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
                    //new Label{Caption = "Memoirs"},
                    //memoir1Button,
                    //new StackLayout
                    //{
                    //    Alignment = Alignment.Horizontal,
                    //    ItemSpacing = 5,
                    //    Items =
                    //    {
                    //        memoir2Button,
                    //        memoir3Button
                    //    }
                    //}
                }
            };
        }
    }
}
