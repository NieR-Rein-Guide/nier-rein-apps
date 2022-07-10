using System;
using ImGui.Forms.Resources;
using nier_rein_gui.Controls.Buttons.Items;
using nier_rein_gui.Resources;
using NierReincarnation.Core.Dark;

namespace nie_rein_gui.Controls.Buttons.Items
{
    class NierConsumableItemButton : NierItemButton
    {
        private readonly DataConsumableItem _item;

        public NierConsumableItemButton(DataConsumableItem item)
        {
            _item = item;
        }

        protected override bool IsPlaceholder() => false;

        protected override ImageResource GetPlaceholder() => null;

        protected override ImageResource GetBackground()
        {
            return NierResources.LoadDefaultBackground();
        }

        protected override ImageResource GetBorder()
        {
            return NierResources.LoadDefaultBorder();
        }

        protected override ImageResource GetContent()
        {
            return NierResources.LoadConsumableItem(_item.AssetCategoryId, _item.AssetVariationId);
        }
    }
}
