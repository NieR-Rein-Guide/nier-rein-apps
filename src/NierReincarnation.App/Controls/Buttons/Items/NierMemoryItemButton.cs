using ImGui.Forms.Resources;
using NierReincarnation.App.Resources;
using NierReincarnation.Core.Dark;

namespace NierReincarnation.App.Controls.Buttons.Items
{
    // TODO: Load correct memory rarity images
    internal class NierMemoryItemButton : NierItemButton
    {
        public DataOutgameMemoryInfo Memory { get; set; }

        protected override bool IsPlaceholder()
        {
            return Memory == null;
        }

        protected override ImageResource GetPlaceholder()
        {
            return NierResources.LoadMemoryPlaceholder();
        }

        protected override ImageResource GetBackground()
        {
            return null;
        }

        protected override ImageResource GetBorder()
        {
            return NierResources.LoadRarityBorder(Memory.RarityType);
        }

        protected override ImageResource GetContent()
        {
            return NierResources.LoadMemoryItem(Memory.GroupAssetId);
        }
    }
}
