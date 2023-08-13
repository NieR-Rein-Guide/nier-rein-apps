using ImGui.Forms.Resources;
using NierReincarnation.App.Resources;
using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Dark.Generated.Type;
using System.Collections.Generic;

namespace NierReincarnation.App.Controls.Buttons.Items
{
    internal class NierCompanionItemButton : NierItemButton
    {
        public DataOutgameCompanionInfo Companion { get; set; }

        protected override bool IsPlaceholder()
        {
            return Companion == null;
        }

        protected override ImageResource GetPlaceholder()
        {
            return NierResources.LoadCompanionPlaceholder();
        }

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
            return NierResources.LoadCompanionItem(Companion?.ActorAssetId);
        }

        protected override ImageResource[] GetIcons()
        {
            var result = new List<ImageResource>();

            if (Companion?.Attribute != AttributeType.UNKNOWN && Companion?.Attribute != AttributeType.NOTHING)
                result.Add(NierResources.LoadAttributeIcon(Companion?.Attribute ?? AttributeType.UNKNOWN));

            return result.ToArray();
        }
    }
}
