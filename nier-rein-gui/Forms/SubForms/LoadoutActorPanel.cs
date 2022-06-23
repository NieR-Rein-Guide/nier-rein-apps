using System;
using System.Linq;
using System.Threading.Tasks;
using ImGui.Forms.Controls;
using ImGui.Forms.Modals;
using nier_rein_gui.Controls.Buttons.Items;
using nier_rein_gui.Dialogs.LoadoutSelectionDialogs;
using NierReincarnation;
using NierReincarnation.Core.Dark;

namespace nier_rein_gui.Forms.SubForms
{
    partial class LoadoutActorPanel : Panel
    {
        private readonly NierReinContexts _rein;

        private DataDeckInfo _deck;
        private DataDeckActorInfo _actor;

        public LoadoutActorPanel(NierReinContexts rein)
        {
            _rein = rein;

            InitializeComponent();

            costumeButton.Clicked += CostumeButton_Clicked;

            mainWeaponButton.Clicked += MainWeaponButton_Clicked;
            subWeapon1Button.Clicked += SubWeapon1Button_Clicked;
            subWeapon2Button.Clicked += SubWeapon2Button_Clicked;
        }

        public void Reset()
        {
            _deck = null;
            _actor = null;

            costumeButton.Costume = null;

            mainWeaponButton.Weapon = null;
            subWeapon1Button.Weapon = null;
            subWeapon2Button.Weapon = null;

            companionButton.Companion = null;

            //SwitchImage(memoir1Button, null);
            //SwitchImage(memoir2Button, null);
            //SwitchImage(memoir3Button, null);
        }

        public void Update(DataDeckInfo deck, DataDeckActorInfo actor)
        {
            _deck = deck;
            _actor = actor;

            costumeButton.Costume = actor.Costume;

            mainWeaponButton.Weapon = actor.MainWeapon;
            subWeapon1Button.Weapon = actor.SubWeapon01;
            subWeapon2Button.Weapon = actor.SubWeapon02;

            companionButton.Companion = actor.Companion;

            //var memory1Icon = NierResources.LoadMemoryIconAsset(actor.Memories[0]);
            //var memory2Icon = NierResources.LoadMemoryIconAsset(actor.Memories[1]);
            //var memory3Icon = NierResources.LoadMemoryIconAsset(actor.Memories[2]);

            //SwitchImage(memoir1Button, memory1Icon?.AsStream());
            //SwitchImage(memoir2Button, memory2Icon?.AsStream());
            //SwitchImage(memoir3Button, memory3Icon?.AsStream());
        }

        private async Task ReplaceDeck()
        {
            if (_deck == null || _actor == null)
                return;

            await _rein.Decks.Replace(_deck);
        }

        #region Costume events

        private async void CostumeButton_Clicked(object sender, EventArgs e)
        {
            var (costumeInfo, shouldReplace) = await SelectCostume(costumeButton, _actor.Costume);
            if (shouldReplace)
                _actor.Costume = costumeInfo;
        }

        private async Task<(DataOutgameCostumeInfo, bool)> SelectCostume(NierCostumeItemButton button, DataOutgameCostumeInfo costume)
        {
            var costumesInDeck = _deck.UserDeckActors.Select(x => x.Costume).ToArray();

            var dlg = new CostumeSelectionDialog(costume, costumesInDeck);
            if (await dlg.ShowAsync() != DialogResult.Ok)
                return (null, false);

            button.Costume = dlg.SelectedItem;

            await ReplaceDeck();

            return (dlg.SelectedItem, true);
        }

        #endregion

        #region Weapon events

        private async void MainWeaponButton_Clicked(object sender, EventArgs e)
        {
            var (weaponInfo, shouldReplace) = await SelectWeapon(mainWeaponButton, _actor.MainWeapon);
            if (shouldReplace)
                _actor.MainWeapon = weaponInfo;
        }

        private async void SubWeapon1Button_Clicked(object sender, EventArgs e)
        {
            var (weaponInfo, shouldReplace) = await SelectWeapon(subWeapon1Button, _actor.MainWeapon);
            if (shouldReplace)
                _actor.SubWeapon01 = weaponInfo;
        }

        private async void SubWeapon2Button_Clicked(object sender, EventArgs e)
        {
            var (weaponInfo, shouldReplace) = await SelectWeapon(subWeapon2Button, _actor.MainWeapon);
            if (shouldReplace)
            {
                if (_actor.SubWeapon01 == null)
                    _actor.SubWeapon01 = weaponInfo;
                else
                    _actor.SubWeapon02 = weaponInfo;
            }
        }

        // TODO: Add remove feature
        private async Task<(DataWeaponInfo, bool)> SelectWeapon(NierWeaponItemButton button, DataWeaponInfo weapon)
        {
            var weaponsInDeck = _deck.UserDeckActors.SelectMany(x => new[] { x.MainWeapon, x.SubWeapon01, x.SubWeapon02 }).Where(x => x != null).ToArray();

            var dlg = new WeaponSelectionDialog(weapon, weaponsInDeck);
            if (await dlg.ShowAsync() != DialogResult.Ok)
                return (null, false);

            button.Weapon = dlg.SelectedItem;

            await ReplaceDeck();

            return (dlg.SelectedItem, true);
        }

        #endregion
    }
}
