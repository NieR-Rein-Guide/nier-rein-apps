using System.Collections.Generic;
using ImGui.Forms.Resources;
using nier_rein_gui.Resources;
using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Dark.Generated.Type;

namespace nier_rein_gui.Controls.Buttons.Items
{
    class NierWeaponItemButton : NierItemButton
    {
        public DataWeaponInfo Weapon { get; set; }

        protected override bool IsPlaceholder()
        {
            return Weapon == null;
        }

        protected override ImageResource GetPlaceholder()
        {
            return NierResources.LoadWeaponPlaceholder();
        }

        protected override ImageResource GetBackground()
        {
            return NierResources.LoadRarityBackground(Weapon?.RarityType ?? RarityType.UNKNOWN);
        }

        protected override ImageResource GetBorder()
        {
            return NierResources.LoadRarityBorder(Weapon?.RarityType ?? RarityType.UNKNOWN);
        }

        protected override ImageResource GetContent()
        {
            return NierResources.LoadWeaponItem(Weapon?.ActorAssetId);
        }

        protected override ImageResource[] GetIcons()
        {
            var result = new List<ImageResource>();

            if (Weapon?.Attribute != AttributeType.UNKNOWN && Weapon?.Attribute != AttributeType.NOTHING)
                result.Add(NierResources.LoadAttributeIcon(Weapon?.Attribute ?? AttributeType.UNKNOWN));
            if (Weapon?.WeaponType != WeaponType.UNKNOWN)
                result.Add(NierResources.LoadWeaponTypeIcon(Weapon?.WeaponType ?? WeaponType.UNKNOWN));
            if (Weapon?.IsEndWeapon ?? false)
                result.Add(NierResources.LoadExIcon());

            return result.ToArray();
        }
    }
}
