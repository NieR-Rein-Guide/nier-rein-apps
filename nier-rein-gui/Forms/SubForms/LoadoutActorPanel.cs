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

            companionButton.Clicked += CompanionButton_Clicked;

            memoir1Button.Clicked += Memoir1Button_Clicked;
            memoir2Button.Clicked += Memoir2Button_Clicked;
            memoir3Button.Clicked += Memoir3Button_Clicked;
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

            memoir1Button.Memory = null;
            memoir2Button.Memory = null;
            memoir3Button.Memory = null;
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

            memoir1Button.Memory = actor.Memories[0];
            memoir2Button.Memory = actor.Memories[1];
            memoir3Button.Memory = actor.Memories[2];
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
            var (costumeInfo, shouldReplace) = await SelectCostume(_actor?.Costume);
            if (!shouldReplace)
                return;

            _actor.Costume = costumeInfo;
            await ReplaceDeck();

            costumeButton.Costume = costumeInfo;
        }

        private async Task<(DataOutgameCostumeInfo, bool)> SelectCostume(DataOutgameCostumeInfo costume)
        {
            var costumesInDeck = _deck?.UserDeckActors.Select(x => x?.Costume).ToArray() ?? Array.Empty<DataOutgameCostumeInfo>();

            var dlg = new CostumeSelectionDialog(costume, costumesInDeck);
            if (await dlg.ShowAsync() != DialogResult.Ok)
                return (null, false);

            return (dlg.SelectedItem, true);
        }

        #endregion

        #region Weapon events

        private async void MainWeaponButton_Clicked(object sender, EventArgs e)
        {
            var (weaponInfo, shouldReplace) = await SelectWeapon(_actor?.MainWeapon);
            if (!shouldReplace)
                return;

            _actor.MainWeapon = weaponInfo;
            await ReplaceDeck();

            mainWeaponButton.Weapon = weaponInfo;
        }

        private async void SubWeapon1Button_Clicked(object sender, EventArgs e)
        {
            var (weaponInfo, shouldReplace) = await SelectWeapon(_actor?.SubWeapon01);
            if (!shouldReplace)
                return;

            _actor.SubWeapon01 = weaponInfo;
            await ReplaceDeck();

            subWeapon1Button.Weapon = weaponInfo;
        }

        private async void SubWeapon2Button_Clicked(object sender, EventArgs e)
        {
            var (weaponInfo, shouldReplace) = await SelectWeapon(_actor?.SubWeapon02);
            if (!shouldReplace)
                return;

            NierWeaponItemButton button;
            if (_actor.SubWeapon01 == null)
            {
                _actor.SubWeapon01 = weaponInfo;
                button = subWeapon1Button;
            }
            else
            {
                _actor.SubWeapon02 = weaponInfo;
                button = subWeapon2Button;
            }

            await ReplaceDeck();

            button.Weapon = weaponInfo;
        }

        // TODO: Add remove feature
        private async Task<(DataWeaponInfo, bool)> SelectWeapon(DataWeaponInfo weapon)
        {
            var weaponsInDeck = _deck?.UserDeckActors.SelectMany(x => new[] { x?.MainWeapon, x?.SubWeapon01, x?.SubWeapon02 }).Where(x => x != null).ToArray() ?? Array.Empty<DataWeaponInfo>();

            var dlg = new WeaponSelectionDialog(weapon, weaponsInDeck);
            if (await dlg.ShowAsync() != DialogResult.Ok)
                return (null, false);

            return (dlg.SelectedItem, true);
        }

        #endregion

        #region Companion events

        private async void CompanionButton_Clicked(object sender, EventArgs e)
        {
            var (companionInfo, shouldReplace) = await SelectCompanion(_actor?.Companion);
            if (!shouldReplace)
                return;

            _actor.Companion = companionInfo;
            await ReplaceDeck();

            companionButton.Companion = companionInfo;
        }

        private async Task<(DataOutgameCompanionInfo, bool)> SelectCompanion(DataOutgameCompanionInfo companion)
        {
            var companionsInDeck = _deck?.UserDeckActors.Select(x => x?.Companion).ToArray() ?? Array.Empty<DataOutgameCompanionInfo>();

            var dlg = new CompanionSelectionDialog(companion, companionsInDeck);
            if (await dlg.ShowAsync() != DialogResult.Ok)
                return (null, false);

            return (dlg.SelectedItem, true);
        }

        #endregion

        #region Memory events

        private async void Memoir1Button_Clicked(object sender, EventArgs e)
        {
            var (memoryInfo, shouldReplace) = await SelectMemory(_actor?.Memories[0]);
            if (!shouldReplace)
                return;

            NierMemoryItemButton button;
            if (_actor.Memories[0] == null)
            {
                _actor.Memories[0] = memoryInfo;
                button = memoir1Button;
            }
            else if (_actor.Memories[1] == null)
            {
                _actor.Memories[1] = memoryInfo;
                button = memoir2Button;
            }
            else
            {
                _actor.Memories[2] = memoryInfo;
                button = memoir3Button;
            }

            await ReplaceDeck();

            button.Memory = memoryInfo;
        }

        private async void Memoir2Button_Clicked(object sender, EventArgs e)
        {
            var (memoryInfo, shouldReplace) = await SelectMemory(_actor?.Memories[1]);
            if (!shouldReplace)
                return;

            NierMemoryItemButton button;
            if (_actor.Memories[0] == null)
            {
                _actor.Memories[0] = memoryInfo;
                button = memoir1Button;
            }
            else if (_actor.Memories[1] == null)
            {
                _actor.Memories[1] = memoryInfo;
                button = memoir2Button;
            }
            else
            {
                _actor.Memories[2] = memoryInfo;
                button = memoir3Button;
            }

            await ReplaceDeck();

            button.Memory = memoryInfo;
        }

        private async void Memoir3Button_Clicked(object sender, EventArgs e)
        {
            var (memoryInfo, shouldReplace) = await SelectMemory(_actor?.Memories[2]);
            if (!shouldReplace)
                return;

            NierMemoryItemButton button;
            if (_actor.Memories[0] == null)
            {
                _actor.Memories[0] = memoryInfo;
                button = memoir1Button;
            }
            else if (_actor.Memories[1] == null)
            {
                _actor.Memories[1] = memoryInfo;
                button = memoir2Button;
            }
            else
            {
                _actor.Memories[2] = memoryInfo;
                button = memoir3Button;
            }

            await ReplaceDeck();

            button.Memory = memoryInfo;
        }

        // TODO: Add remove feature
        private async Task<(DataOutgameMemoryInfo, bool)> SelectMemory(DataOutgameMemoryInfo memory)
        {
            var memoriesInDeck = _deck?.UserDeckActors.SelectMany(x => x?.Memories).Where(x => x != null).ToArray() ?? Array.Empty<DataOutgameMemoryInfo>();

            var dlg = new MemorySelectionDialog(memory, memoriesInDeck);
            if (await dlg.ShowAsync() != DialogResult.Ok)
                return (null, false);

            return (dlg.SelectedItem, true);
        }

        #endregion
    }
}
