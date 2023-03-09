using ImGui.Forms.Resources;
using NierReincarnation.App.Resources;
using NierReincarnation.Core.Dark;

namespace NierReincarnation.App.Controls.Buttons.Items
{
    internal class NierConsumableItemButton : NierItemButton
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
