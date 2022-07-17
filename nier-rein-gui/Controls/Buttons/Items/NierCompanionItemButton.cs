using System.Collections.Generic;
using ImGui.Forms.Resources;
using nier_rein_gui.Resources;
using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.View.UserInterface.Outgame;

namespace nier_rein_gui.Controls.Buttons.Items
{
    class NierThoughtItemButton : NierItemButton
    {
        public DataOutgameThought Thought { get; set; }

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
