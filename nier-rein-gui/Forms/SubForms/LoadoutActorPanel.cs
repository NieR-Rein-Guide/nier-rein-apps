using System;
using System.Linq;
using System.Threading.Tasks;
using ImGui.Forms.Controls;
using ImGui.Forms.Modals;
using ImGui.Forms.Resources;
using nier_rein_gui.Controls.Buttons;
using nier_rein_gui.Dialogs;
using nier_rein_gui.Dialogs.LoadoutSelectionDialogs;
using nier_rein_gui.Resources;
using NierReincarnation;
using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.UnityEngine;
using SixLabors.ImageSharp.Processing;

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

            UpdateCostume(costumeButton, null, null);

            UpdateWeaponButton(mainWeaponButton, null, null);
            UpdateWeaponButton(subWeapon1Button, null, null);
            UpdateWeaponButton(subWeapon2Button, null, null);

            UpdateCompanion(companionButton, null, null);

            //SwitchImage(memoir1Button, null);
            //SwitchImage(memoir2Button, null);
            //SwitchImage(memoir3Button, null);
        }

        public void Update(DataDeckInfo deck, DataDeckActorInfo actor)
        {
            _deck = deck;
            _actor = actor;

            UpdateCostume(costumeButton, NierResources.LoadCostumeIconAsset(actor.Costume?.ActorAssetId), actor.Costume);

            UpdateWeaponButton(mainWeaponButton, NierResources.LoadWeaponIconAsset(actor.MainWeapon?.ActorAssetId), actor.MainWeapon);
            UpdateWeaponButton(subWeapon1Button, NierResources.LoadWeaponIconAsset(actor.SubWeapon01?.ActorAssetId), actor.SubWeapon01);
            UpdateWeaponButton(subWeapon2Button, NierResources.LoadWeaponIconAsset(actor.SubWeapon02?.ActorAssetId), actor.SubWeapon02);

            UpdateCompanion(companionButton, NierResources.LoadCompanionIconAsset(actor.Companion?.ActorAssetId), actor.Companion);

            //var memory1Icon = NierResources.LoadMemoryIconAsset(actor.Memories[0]);
            //var memory2Icon = NierResources.LoadMemoryIconAsset(actor.Memories[1]);
            //var memory3Icon = NierResources.LoadMemoryIconAsset(actor.Memories[2]);

            //SwitchImage(memoir1Button, memory1Icon?.AsStream());
            //SwitchImage(memoir2Button, memory2Icon?.AsStream());
            //SwitchImage(memoir3Button, memory3Icon?.AsStream());
        }

        private void UpdateCostume(NierIconButton button, ImageAsset asset, DataOutgameCostumeInfo costume)
        {
            UpdateButton(button, asset);

            button.Attribute = AttributeType.UNKNOWN;
            button.WeaponType = costume?.WeaponType ?? WeaponType.UNKNOWN;
            button.RarityType = costume?.RarityType ?? RarityType.UNKNOWN;
            button.IsEnd = false;
        }

        private void UpdateWeaponButton(NierIconButton button, ImageAsset asset, DataWeaponInfo weapon)
        {
            UpdateButton(button, asset);

            button.Attribute = weapon?.Attribute ?? AttributeType.UNKNOWN;
            button.WeaponType = weapon?.WeaponType ?? WeaponType.UNKNOWN;
            button.RarityType = weapon?.RarityType ?? RarityType.UNKNOWN;
            button.IsEnd = weapon?.IsEndWeapon ?? false;
        }

        private void UpdateCompanion(NierIconButton button, ImageAsset asset, DataOutgameCompanionInfo companion)
        {
            UpdateButton(button, asset);

            button.Attribute = AttributeType.UNKNOWN;
            button.WeaponType = WeaponType.UNKNOWN;
            // TODO: Set rarity type for companion; Set weapon type to companion?
            button.RarityType = RarityType.SS_RARE;
            button.IsEnd = false;
        }

        private void UpdateButton(NierIconButton button, ImageAsset asset)
        {
            asset?.Image.Mutate(x => x.Resize(new SixLabors.ImageSharp.Size((int)NierResources.IconSize.X, (int)NierResources.IconSize.Y)));
            var imgStream = asset?.AsStream();

            if (imgStream == null)
            {
                button.Image?.Destroy();
                button.Image = null;

                return;
            }

            // TODO: Release old image resources; Necessary rework of setting ImageResource
            button.Image = button.Image?.Replace(imgStream) ?? ImageResource.FromStream(imgStream);
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

        private async Task<(DataOutgameCostumeInfo, bool)> SelectCostume(NierIconButton button, DataOutgameCostumeInfo costume)
        {
            var costumesInDeck = _deck.UserDeckActors.Select(x => x.Costume).ToArray();

            var dlg = new CostumeSelectionDialog(costume, costumesInDeck);
            if (await dlg.ShowAsync() != DialogResult.Ok)
                return (null, false);

            UpdateCostume(button, NierResources.LoadCostumeIconAsset(dlg.SelectedItem.ActorAssetId), dlg.SelectedItem);

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
        private async Task<(DataWeaponInfo, bool)> SelectWeapon(NierIconButton button, DataWeaponInfo weapon)
        {
            var weaponsInDeck = _deck.UserDeckActors.SelectMany(x => new[] { x.MainWeapon, x.SubWeapon01, x.SubWeapon02 }).Where(x => x != null).ToArray();

            var dlg = new WeaponSelectionDialog(weapon, weaponsInDeck);
            if (await dlg.ShowAsync() != DialogResult.Ok)
                return (null, false);

            UpdateWeaponButton(button, NierResources.LoadWeaponIconAsset(dlg.SelectedItem.ActorAssetId), dlg.SelectedItem);

            await ReplaceDeck();

            return (dlg.SelectedItem, true);
        }

        #endregion
    }
}
