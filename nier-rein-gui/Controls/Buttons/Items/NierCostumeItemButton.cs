﻿using System.Collections.Generic;
using ImGui.Forms.Resources;
using nier_rein_gui.Resources;
using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Dark.Generated.Type;

namespace nier_rein_gui.Controls.Buttons.Items
{
    class NierCostumeItemButton : NierItemButton
    {
        private ImageResource _itemResource;
        private ImageResource _bgResource;
        private ImageResource _borderResource;

        private ImageResource _weaponResource;

        private DataOutgameCostumeInfo _costumeInfo;

        #region Properties

        public DataOutgameCostumeInfo Costume
        {
            get => _costumeInfo;
            set
            {
                _costumeInfo = value;

                LoadCostumeResource(value?.ActorAssetId);

                LoadWeaponTypeIcon(value?.WeaponType ?? WeaponType.UNKNOWN);
                LoadRarityTypeResources(value?.RarityType ?? RarityType.UNKNOWN);
            }
        }

        #endregion

        protected override ImageResource GetBackground()
        {
            return _bgResource;
        }

        protected override ImageResource GetBorder()
        {
            return _borderResource;
        }

        protected override ImageResource GetContent()
        {
            return _itemResource;
        }

        protected override ImageResource[] GetIcons()
        {
            var result = new List<ImageResource>();

            if (_weaponResource != null)
                result.Add(_weaponResource);

            return result.ToArray();
        }

        private void LoadCostumeResource(ActorAssetId assetId)
        {
            _itemResource?.Destroy();
            _itemResource = null;

            if (assetId == null)
                return;

            _itemResource = LoadItemResource(NierResources.LoadCostumeIconAsset(assetId));
        }

        private void LoadWeaponTypeIcon(WeaponType weaponType)
        {
            _weaponResource?.Destroy();
            _weaponResource = null;

            switch (weaponType)
            {
                case WeaponType.UNKNOWN:
                case WeaponType.COMPANION:
                case WeaponType.MT_WEAPON:
                    break;

                default:
                    _weaponResource = LoadIconResource(NierResources.LoadWeaponTypeIcon(weaponType));
                    break;
            }
        }

        private void LoadRarityTypeResources(RarityType rarityTpe)
        {
            _bgResource?.Destroy();
            _borderResource?.Destroy();

            _bgResource = null;
            _borderResource = null;

            switch (rarityTpe)
            {
                case RarityType.UNKNOWN:
                    break;

                default:
                    _bgResource = LoadItemResource(NierResources.LoadRarityBackground(rarityTpe));
                    _borderResource = LoadItemResource(NierResources.LoadRarityBorder(rarityTpe));
                    break;
            }
        }
    }
}
