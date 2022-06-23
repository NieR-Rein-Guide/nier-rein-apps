using ImGui.Forms.Resources;
using nier_rein_gui.Resources;
using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Dark.Generated.Type;

namespace nier_rein_gui.Controls.Buttons.Items
{
    class NierCompanionItemButton : NierItemButton
    {
        private ImageResource _itemResource;
        private ImageResource _bgResource;
        private ImageResource _borderResource;

        private ImageResource _attributeResource;

        private DataOutgameCompanionInfo _companionInfo;

        #region Properties

        public DataOutgameCompanionInfo Companion
        {
            get => _companionInfo;
            set
            {
                _companionInfo = value;

                LoadCompanionResources(value?.ActorAssetId);
                LoadAttributeIcon(value?.Attribute ?? AttributeType.UNKNOWN);
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
            if (_attributeResource != null)
                return new[] {_attributeResource};

            return base.GetIcons();
        }

        private void LoadCompanionResources(ActorAssetId assetId)
        {
            _itemResource?.Destroy();
            _borderResource?.Destroy();
            _bgResource?.Destroy();

            _itemResource = null;
            _borderResource = null;
            _bgResource = null;

            if (assetId == null)
                return;

            _itemResource = LoadItemResource(NierResources.LoadCompanionIconAsset(assetId));
            _borderResource = LoadItemResource(NierResources.LoadCompanionBorder());
            _bgResource = LoadItemResource(NierResources.LoadCompanionBackground());
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
    }
}
