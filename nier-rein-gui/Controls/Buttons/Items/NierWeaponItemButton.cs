using System.Collections.Generic;
using ImGui.Forms.Resources;
using nier_rein_gui.Resources;
using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Dark.Generated.Type;

namespace nier_rein_gui.Controls.Buttons.Items
{
    class NierWeaponItemButton : NierItemButton
    {
        private ImageResource _itemResource;
        private ImageResource _bgResource;
        private ImageResource _borderResource;
        private ImageResource _isEndResource;

        private ImageResource _attributeResource;
        private ImageResource _weaponResource;

        private DataWeaponInfo _weaponInfo;

        #region Properties

        public DataWeaponInfo Weapon
        {
            get => _weaponInfo;
            set
            {
                _weaponInfo = value;

                LoadWeaponResource(value?.ActorAssetId);

                LoadAttributeIcon(value?.Attribute ?? AttributeType.UNKNOWN);
                LoadWeaponTypeIcon(value?.WeaponType ?? WeaponType.UNKNOWN);
                LoadRarityTypeResources(value?.RarityType ?? RarityType.UNKNOWN);

                if (value?.IsEndWeapon ?? false)
                    LoadIsEndIcon();
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

            if(_attributeResource!=null)
                result.Add(_attributeResource);
            if (_weaponResource != null)
                result.Add(_weaponResource);
            if (_isEndResource != null)
                result.Add(_isEndResource);

            return result.ToArray();
        }

        private void LoadWeaponResource(ActorAssetId assetId)
        {
            _itemResource?.Destroy();
            _itemResource = null;

            if (assetId == null)
                return;

            _itemResource = LoadItemResource(NierResources.LoadWeaponIconAsset(assetId));
        }

        private void LoadAttributeIcon(AttributeType attribute)
        {
            _attributeResource?.Destroy();
            _attributeResource = null;

            switch (attribute)
            {
                case AttributeType.NOTHING:
                case AttributeType.UNKNOWN:
                    break;

                default:
                    _attributeResource = LoadIconResource(NierResources.LoadAttributeIcon(attribute));
                    break;
            }
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

        private void LoadIsEndIcon()
        {
            if (_isEndResource != null)
                return;

            _isEndResource = LoadIconResource(NierResources.LoadExIcon());
        }
    }
}
