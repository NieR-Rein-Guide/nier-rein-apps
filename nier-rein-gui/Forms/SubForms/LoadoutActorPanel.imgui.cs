using ImGui.Forms.Controls;
using ImGui.Forms.Controls.Layouts;
using ImGui.Forms.Controls.Lists;
using nier_rein_gui.Controls.Buttons;
using nier_rein_gui.Resources;

namespace nier_rein_gui.Forms.SubForms
{
    partial class LoadoutActorPanel
    {
        private NierIconButton costumeButton;
        private NierIconButton companionButton;
        private NierIconButton mainWeaponButton;
        private NierIconButton subWeapon1Button;
        private NierIconButton subWeapon2Button;
        //private NierIconButton memoir1Button;
        //private NierIconButton memoir2Button;
        //private NierIconButton memoir3Button;

        private void InitializeComponent()
        {
            costumeButton = new NierIconButton { EmptySize = NierResources.IconSize };
            companionButton = new NierIconButton { EmptySize = NierResources.IconSize };
            mainWeaponButton = new NierIconButton { EmptySize = NierResources.IconSize };
            subWeapon1Button = new NierIconButton { EmptySize = NierResources.IconSize };
            subWeapon2Button = new NierIconButton { EmptySize = NierResources.IconSize };
            //memoir1Button = new NierIconButton { EmptySize = NierResources.IconSize };
            //memoir2Button = new NierIconButton { EmptySize = NierResources.IconSize };
            //memoir3Button = new NierIconButton { EmptySize = NierResources.IconSize };

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
