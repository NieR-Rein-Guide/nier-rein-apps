using System.Collections.Generic;
using ImGui.Forms.Resources;
using nier_rein_gui.Resources;
using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Dark.Generated.Type;

namespace nier_rein_gui.Controls.Buttons.Items
{
    class NierCostumeItemButton : NierItemButton
    {
        public DataOutgameCostumeInfo Costume { get; set; }

        protected override bool IsPlaceholder()
        {
            return Costume == null;
        }

        protected override ImageResource GetPlaceholder()
        {
            return NierResources.LoadCostumePlaceholder();
        }

        protected override ImageResource GetBackground()
        {
            return NierResources.LoadRarityBackground(Costume?.RarityType ?? RarityType.UNKNOWN);
        }

        protected override ImageResource GetBorder()
        {
            return NierResources.LoadRarityBorder(Costume?.RarityType ?? RarityType.UNKNOWN);
        }

        protected override ImageResource GetContent()
        {
            return NierResources.LoadCostumeItem(Costume?.ActorAssetId);
        }

        protected override ImageResource[] GetIcons()
        {
            var result = new List<ImageResource>();

            if (Costume?.WeaponType != WeaponType.UNKNOWN)
                result.Add(NierResources.LoadWeaponTypeIcon(Costume?.WeaponType ?? WeaponType.UNKNOWN));

            return result.ToArray();
        }
    }
}
