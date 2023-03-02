using ImGui.Forms.Resources;
using NierReincarnation.App.Resources;
using NierReincarnation.Core.Dark;

namespace NierReincarnation.App.Controls.Buttons.Items
{
    internal class NierThoughtItemButton : NierItemButton
    {
        public DataOutgameThoughtInfo Thought { get; set; }

        protected override bool IsPlaceholder()
        {
            return Thought == null;
        }

        protected override ImageResource GetPlaceholder()
        {
            return NierResources.LoadThoughtPlaceholder();
        }

        protected override ImageResource GetBackground()
        {
            return NierResources.LoadRarityBackground(Thought.RarityType);
        }

        protected override ImageResource GetBorder()
        {
            return NierResources.LoadRarityBorder(Thought.RarityType);
        }

        protected override ImageResource GetContent()
        {
            return NierResources.LoadThoughtItem(Thought.ThoughtAssetId);
        }
    }
}
