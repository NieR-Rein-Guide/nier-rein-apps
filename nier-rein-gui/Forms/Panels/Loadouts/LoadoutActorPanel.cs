using System;
using System.Linq;
using System.Threading.Tasks;
using ImGui.Forms.Controls;
using nier_rein_gui.Controls.Buttons.Items;
using nier_rein_gui.Dialogs.LoadoutSelectionDialogs;
using NierReincarnation;
using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Dark.View.UserInterface.Outgame;

namespace nier_rein_gui.Forms.Panels.Loadouts
{
    partial class LoadoutActorPanel : Panel
    {
        private readonly NierReinContexts _rein;
        private readonly LoadoutPanel _loadoutPanel;
        private readonly int _pos;

        private DataDeckActorInfo _actor;

        public LoadoutActorPanel(NierReinContexts rein, LoadoutPanel loadoutPanel, int pos)
        {
            _rein = rein;
            _loadoutPanel = loadoutPanel;
            _pos = pos;

            InitializeComponent();

            costumeButton.Clicked += CostumeButton_Clicked;

            mainWeaponButton.Clicked += MainWeaponButton_Clicked;
            subWeapon1Button.Clicked += SubWeapon1Button_Clicked;
            subWeapon2Button.Clicked += SubWeapon2Button_Clicked;

            companionButton.Clicked += CompanionButton_Clicked;
            thoughtButton.Clicked += ThoughtButton_Clicked;

            memoir1Button.Clicked += Memoir1Button_Clicked;
            memoir2Button.Clicked += Memoir2Button_Clicked;
            memoir3Button.Clicked += Memoir3Button_Clicked;
        }

        public void Reset(bool canSet)
        {
            _actor = null;

            costumeButton.Costume = null;

            mainWeaponButton.Weapon = null;
            subWeapon1Button.Weapon = null;
            subWeapon2Button.Weapon = null;

            companionButton.Companion = null;
            thoughtButton.Thought = null;

            memoir1Button.Memory = null;
            memoir2Button.Memory = null;
            memoir3Button.Memory = null;

            costumeButton.Enabled = canSet;

            mainWeaponButton.Enabled = false;
            subWeapon1Button.Enabled = false;
            subWeapon2Button.Enabled = false;

            companionButton.Enabled = false;
            thoughtButton.Enabled = false;

            memoir1Button.Enabled = false;
            memoir2Button.Enabled = false;
            memoir3Button.Enabled = false;

            _loadoutPanel.UpdateActor(_pos);
        }

        public void Update(DataDeckActorInfo actor)
        {
            _actor = actor;

            costumeButton.Costume = actor.Costume;

            mainWeaponButton.Weapon = actor.MainWeapon;
            subWeapon1Button.Weapon = actor.SubWeapon01;
            subWeapon2Button.Weapon = actor.SubWeapon02;

            companionButton.Companion = actor.Companion;
            thoughtButton.Thought = actor.Thought;

            memoir1Button.Memory = actor.Memories[0];
            memoir2Button.Memory = actor.Memories[1];
            memoir3Button.Memory = actor.Memories[2];

            costumeButton.Enabled = true;

            mainWeaponButton.Enabled = true;
            subWeapon1Button.Enabled = true;
            subWeapon2Button.Enabled = true;

            companionButton.Enabled = true;
            thoughtButton.Enabled = true;

            memoir1Button.Enabled = true;
            memoir2Button.Enabled = true;
            memoir3Button.Enabled = true;

            _loadoutPanel.UpdateActor(_pos);
        }

        #region Costume events

        private async void CostumeButton_Clicked(object sender, EventArgs e)
        {
            var (costumeInfo, _) = await SelectCostume(_actor?.Costume);
            if (costumeInfo == null)
                return;

            if (_actor?.Costume != null)
            {
                _actor.Costume = costumeInfo;
                await _loadoutPanel.ReplaceDeck();

                costumeButton.Costume = costumeInfo;

                return;
            }

            var (weaponInfo, _) = await SelectWeapon(null, true);
            if (weaponInfo == null)
                return;

            _actor ??= _loadoutPanel.CreateActor(_pos);

            _actor.Costume = costumeInfo;
            _actor.MainWeapon = weaponInfo;
            await _loadoutPanel.ReplaceDeck();

            costumeButton.Costume = costumeInfo;
            mainWeaponButton.Weapon = weaponInfo;

            mainWeaponButton.Enabled = true;
            subWeapon1Button.Enabled = true;
            subWeapon2Button.Enabled = true;

            companionButton.Enabled = true;
            thoughtButton.Enabled = true;

            memoir1Button.Enabled = true;
            memoir2Button.Enabled = true;
            memoir3Button.Enabled = true;

            _loadoutPanel.UpdateActor(_pos);
        }

        private async Task<(DataOutgameCostumeInfo, bool)> SelectCostume(DataOutgameCostumeInfo costume)
        {
            var costumesInDeck = _loadoutPanel.GetOtherDeckCostumes(_pos);

            var dlg = new CostumeSelectionDialog(costume, costumesInDeck);
            await dlg.ShowAsync();

            return (dlg.SelectedItem, dlg.ShouldRemove);
        }

        #endregion

        #region Weapon events

        private async void MainWeaponButton_Clicked(object sender, EventArgs e)
        {
            var (weaponInfo, _) = await SelectWeapon(_actor?.MainWeapon, true);
            if (weaponInfo == null)
                return;

            _actor.MainWeapon = weaponInfo;
            await _loadoutPanel.ReplaceDeck();

            mainWeaponButton.Weapon = weaponInfo;

            _loadoutPanel.UpdateActor(_pos);
        }

        private async void SubWeapon1Button_Clicked(object sender, EventArgs e)
        {
            var (weaponInfo, shouldRemove) = await SelectWeapon(_actor?.SubWeapon01, false);
            if (weaponInfo == null && !shouldRemove)
                return;

            if (shouldRemove)
            {
                _actor.SubWeapon01 = _actor.SubWeapon02;
                if (_actor.SubWeapon02 != null)
                    _actor.SubWeapon02 = null;

                await _loadoutPanel.ReplaceDeck();

                subWeapon1Button.Weapon = subWeapon2Button.Weapon;
                subWeapon2Button.Weapon = null;

                return;
            }

            _actor.SubWeapon01 = weaponInfo;
            await _loadoutPanel.ReplaceDeck();

            subWeapon1Button.Weapon = weaponInfo;

            _loadoutPanel.UpdateActor(_pos);
        }

        private async void SubWeapon2Button_Clicked(object sender, EventArgs e)
        {
            var (weaponInfo, shouldRemove) = await SelectWeapon(_actor?.SubWeapon02, false);
            if (weaponInfo == null && !shouldRemove)
                return;

            if (shouldRemove)
            {
                _actor.SubWeapon02 = null;
                await _loadoutPanel.ReplaceDeck();

                subWeapon2Button.Weapon = null;

                return;
            }

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

            await _loadoutPanel.ReplaceDeck();

            button.Weapon = weaponInfo;

            _loadoutPanel.UpdateActor(_pos);
        }

        private async Task<(DataWeaponInfo, bool)> SelectWeapon(DataWeaponInfo weapon, bool isMain)
        {
            var weaponsInOtherDecks = _loadoutPanel.GetOtherDeckWeapons(_pos);
            var weaponsInDeck = new[] { _actor?.MainWeapon, _actor?.SubWeapon01, _actor?.SubWeapon02 }.Where(x => x != null && x.WeaponId != weapon?.WeaponId).ToArray();

            var dlg = new WeaponSelectionDialog(weapon, isMain, weaponsInDeck, weaponsInOtherDecks);
            await dlg.ShowAsync();

            return (dlg.SelectedItem, dlg.ShouldRemove);
        }

        #endregion

        #region Companion events

        private async void CompanionButton_Clicked(object sender, EventArgs e)
        {
            var (companionInfo, shouldRemove) = await SelectCompanion(_actor?.Companion);
            if (companionInfo == null && !shouldRemove)
                return;

            _actor.Companion = companionInfo;
            await _loadoutPanel.ReplaceDeck();

            companionButton.Companion = companionInfo;

            _loadoutPanel.UpdateActor(_pos);
        }

        private async Task<(DataOutgameCompanionInfo, bool)> SelectCompanion(DataOutgameCompanionInfo companion)
        {
            var companionsInDeck = _loadoutPanel.GetDeckCompanions(_pos);

            var dlg = new CompanionSelectionDialog(companion, companionsInDeck);
            await dlg.ShowAsync();

            return (dlg.SelectedItem, dlg.ShouldRemove);
        }

        #endregion

        #region Thought events

        private async void ThoughtButton_Clicked(object sender, EventArgs e)
        {
            var (thought, shouldRemove) = await SelectThought(_actor?.Thought);
            if (thought == null && !shouldRemove)
                return;

            _actor.Thought = thought;
            await _loadoutPanel.ReplaceDeck();

            thoughtButton.Thought = thought;

            _loadoutPanel.UpdateActor(_pos);
        }

        private async Task<(DataOutgameThoughtInfo, bool)> SelectThought(DataOutgameThoughtInfo thought)
        {
            var thoughtsInDeck = _loadoutPanel.GetDeckThoughts(_pos);

            var dlg = new ThoughtSelectionDialog(thought, thoughtsInDeck);
            await dlg.ShowAsync();

            return (dlg.SelectedItem, dlg.ShouldRemove);
        }

        #endregion

        #region Memory events

        private async void Memoir1Button_Clicked(object sender, EventArgs e)
        {
            var (memoryInfo, shouldRemove) = await SelectMemory(_actor?.Memories[0]);
            if (memoryInfo == null && !shouldRemove)
                return;

            if (shouldRemove)
            {
                _actor.Memories[0] = _actor.Memories[1];
                _actor.Memories[1] = _actor.Memories[2];
                _actor.Memories[2] = null;

                await _loadoutPanel.ReplaceDeck();

                memoir1Button.Memory = _actor.Memories[0];
                memoir2Button.Memory = _actor.Memories[1];
                memoir3Button.Memory = _actor.Memories[2];

                _loadoutPanel.UpdateActor(_pos);

                return;
            }

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

            await _loadoutPanel.ReplaceDeck();

            button.Memory = memoryInfo;

            _loadoutPanel.UpdateActor(_pos);
        }

        private async void Memoir2Button_Clicked(object sender, EventArgs e)
        {
            var (memoryInfo, shouldRemove) = await SelectMemory(_actor?.Memories[1]);
            if (memoryInfo == null && !shouldRemove)
                return;

            if (shouldRemove)
            {
                _actor.Memories[1] = _actor.Memories[2];
                _actor.Memories[2] = null;

                await _loadoutPanel.ReplaceDeck();

                memoir2Button.Memory = _actor.Memories[1];
                memoir3Button.Memory = _actor.Memories[2];

                _loadoutPanel.UpdateActor(_pos);

                return;
            }

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

            await _loadoutPanel.ReplaceDeck();

            button.Memory = memoryInfo;

            _loadoutPanel.UpdateActor(_pos);
        }

        private async void Memoir3Button_Clicked(object sender, EventArgs e)
        {
            var (memoryInfo, shouldRemove) = await SelectMemory(_actor?.Memories[2]);
            if (memoryInfo == null && !shouldRemove)
                return;

            if (shouldRemove)
            {
                _actor.Memories[2] = null;
                await _loadoutPanel.ReplaceDeck();

                memoir3Button.Memory = _actor.Memories[2];

                _loadoutPanel.UpdateActor(_pos);

                return;
            }

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

            await _loadoutPanel.ReplaceDeck();

            button.Memory = memoryInfo;

            _loadoutPanel.UpdateActor(_pos);
        }

        private async Task<(DataOutgameMemoryInfo, bool)> SelectMemory(DataOutgameMemoryInfo memory)
        {
            var memoriesInOtherDeck = _loadoutPanel.GetDeckMemoirs(_pos);
            var memoriesInDeck = _actor?.Memories.Where(x => x != null && x.UserMemoryUuid != memory?.UserMemoryUuid).ToArray() ?? Array.Empty<DataOutgameMemoryInfo>();

            var dlg = new MemorySelectionDialog(memory, memoriesInDeck, memoriesInOtherDeck);
            await dlg.ShowAsync();

            return (dlg.SelectedItem, dlg.ShouldRemove);
        }

        #endregion
    }
}
