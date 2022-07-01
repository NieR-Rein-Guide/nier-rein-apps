using ImGui.Forms.Resources;
using nier_rein_gui.Resources;
using NierReincarnation.Core.Dark;

namespace nier_rein_gui.Controls.Buttons.Items
{
    // TODO: Load correct memory rarity images
    class NierMemoryItemButton : NierItemButton
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
