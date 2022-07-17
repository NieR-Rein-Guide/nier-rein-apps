using System;
using System.Linq;
using System.Threading.Tasks;
using ImGui.Forms.Controls;
using ImGui.Forms.Modals;
using nier_rein_gui.Controls.Buttons.Items;
using nier_rein_gui.Dialogs.LoadoutSelectionDialogs;
using NierReincarnation;
using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Dark.View.UserInterface.Outgame;

namespace nier_rein_gui.Forms.SubForms
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
        }

        #region Costume events

        private async void CostumeButton_Clicked(object sender, EventArgs e)
        {
            var (costumeInfo, shouldReplace) = await SelectCostume(_actor?.Costume);
            if (!shouldReplace)
                return;

            if (_actor?.Costume != null)
            {
                _actor.Costume = costumeInfo;
                await _loadoutPanel.ReplaceDeck();

                costumeButton.Costume = costumeInfo;

                return;
            }

            var (weaponInfo, shouldReplace2) = await SelectWeapon(null);
            if (!shouldReplace2)
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

            memoir1Button.Enabled = true;
            memoir2Button.Enabled = true;
            memoir3Button.Enabled = true;
        }

        private async Task<(DataOutgameCostumeInfo, bool)> SelectCostume(DataOutgameCostumeInfo costume)
        {
            var costumesInDeck = _loadoutPanel.GetOtherDeckCostumes(_pos);

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
            await _loadoutPanel.ReplaceDeck();

            mainWeaponButton.Weapon = weaponInfo;
        }

        private async void SubWeapon1Button_Clicked(object sender, EventArgs e)
        {
            var (weaponInfo, shouldReplace) = await SelectWeapon(_actor?.SubWeapon01);
            if (!shouldReplace)
                return;

            _actor.SubWeapon01 = weaponInfo;
            await _loadoutPanel.ReplaceDeck();

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

            await _loadoutPanel.ReplaceDeck();

            button.Weapon = weaponInfo;
        }

        // TODO: Add remove feature
        private async Task<(DataWeaponInfo, bool)> SelectWeapon(DataWeaponInfo weapon)
        {
            var weaponsInOtherDecks = _loadoutPanel.GetOtherDeckWeapons(_pos);
            var weaponsInDeck = new[] { _actor?.MainWeapon, _actor?.SubWeapon01, _actor?.SubWeapon02 }.Where(x => x != null && x.WeaponId != weapon.WeaponId).ToArray();

            var dlg = new WeaponSelectionDialog(weapon, weaponsInDeck, weaponsInOtherDecks);
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
            await _loadoutPanel.ReplaceDeck();

            companionButton.Companion = companionInfo;
        }

        private async Task<(DataOutgameCompanionInfo, bool)> SelectCompanion(DataOutgameCompanionInfo companion)
        {
            var companionsInDeck = _loadoutPanel.GetDeckCompanions(_pos);

            var dlg = new CompanionSelectionDialog(companion, companionsInDeck);
            if (await dlg.ShowAsync() != DialogResult.Ok)
                return (null, false);

            return (dlg.SelectedItem, true);
        }

        #endregion

        #region Thought events

        private async void ThoughtButton_Clicked(object sender, EventArgs e)
        {
            var (thought, shouldReplace) = await SelectThought(_actor?.Thought);
            if (!shouldReplace)
                return;

            _actor.Thought = thought;
            await _loadoutPanel.ReplaceDeck();

            thoughtButton.Thought = thought;
        }

        private async Task<(DataOutgameThought, bool)> SelectThought(DataOutgameThought thought)
        {
            var thoughtsInDeck = _loadoutPanel.GetDeckThoughts(_pos);

            var dlg = new ThoughtSelectionDialog(thought, thoughtsInDeck);
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

            await _loadoutPanel.ReplaceDeck();

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

            await _loadoutPanel.ReplaceDeck();

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

            await _loadoutPanel.ReplaceDeck();

            button.Memory = memoryInfo;
        }

        // TODO: Add remove feature
        private async Task<(DataOutgameMemoryInfo, bool)> SelectMemory(DataOutgameMemoryInfo memory)
        {
            var memoriesInOtherDeck = _loadoutPanel.GetDeckMemoirs(_pos);
            var memoriesInDeck = _actor?.Memories.Where(x => x != null && x.PartsId != memory.PartsId).ToArray() ?? Array.Empty<DataOutgameMemoryInfo>();

            var dlg = new MemorySelectionDialog(memory, memoriesInDeck, memoriesInOtherDeck);
            if (await dlg.ShowAsync() != DialogResult.Ok)
                return (null, false);

            return (dlg.SelectedItem, true);
        }

        #endregion
    }
}
