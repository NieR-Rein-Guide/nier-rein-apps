using System;
using System.Numerics;
using ImGui.Forms.Resources;
using nier_rein_gui.Resources;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.UnityEngine;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using Rectangle = Veldrid.Rectangle;

namespace nier_rein_gui.Controls.CheckBoxes
{
    class NierWeaponCheckbox : NierIconCheckbox
    {
        private static ImageResource BigSwordIconResource;
        private static ImageResource SwordIconResource;
        private static ImageResource SpearIconResource;
        private static ImageResource StaffIconResource;
        private static ImageResource GunIconResource;
        private static ImageResource FistIconResource;

        private static readonly Vector2 WeaponIconSize = new Vector2(20, 20);

        public WeaponType WeaponType { get; set; }

        protected override Vector2 GetIconSize()
        {
            return WeaponIconSize;
        }

        protected override void DrawIcon(Rectangle contentRect)
        {
            var pos = contentRect.Position + GetIconPosition();
            switch (WeaponType)
            {
                case WeaponType.SWORD:
                    if (SwordIconResource == null)
                        SwordIconResource = LoadIcon(NierResources.LoadWeaponTypeIcon(WeaponType));

                    ImGuiNET.ImGui.GetWindowDrawList().AddImage((IntPtr)SwordIconResource, pos, pos + WeaponIconSize);
                    break;

                case WeaponType.BIG_SWORD:
                    if (BigSwordIconResource == null)
                        BigSwordIconResource = LoadIcon(NierResources.LoadWeaponTypeIcon(WeaponType));

                    ImGuiNET.ImGui.GetWindowDrawList().AddImage((IntPtr)BigSwordIconResource, pos, pos + WeaponIconSize);
                    break;

                case WeaponType.GUN:
                    if (GunIconResource == null)
                        GunIconResource = LoadIcon(NierResources.LoadWeaponTypeIcon(WeaponType));

                    ImGuiNET.ImGui.GetWindowDrawList().AddImage((IntPtr)GunIconResource, pos, pos + WeaponIconSize);
                    break;

                case WeaponType.STAFF:
                    if (StaffIconResource == null)
                        StaffIconResource = LoadIcon(NierResources.LoadWeaponTypeIcon(WeaponType));

                    ImGuiNET.ImGui.GetWindowDrawList().AddImage((IntPtr)StaffIconResource, pos, pos + WeaponIconSize);
                    break;

                case WeaponType.SPEAR:
                    if (SpearIconResource == null)
                        SpearIconResource = LoadIcon(NierResources.LoadWeaponTypeIcon(WeaponType));

                    ImGuiNET.ImGui.GetWindowDrawList().AddImage((IntPtr)SpearIconResource, pos, pos + WeaponIconSize);
                    break;

                case WeaponType.FIST:
                    if (FistIconResource == null)
                        FistIconResource = LoadIcon(NierResources.LoadWeaponTypeIcon(WeaponType));

                    ImGuiNET.ImGui.GetWindowDrawList().AddImage((IntPtr)FistIconResource, pos, pos + WeaponIconSize);
                    break;
            }
        }

        private ImageResource LoadIcon(ImageAsset asset)
        {
            asset.Image.Mutate(x => x.Resize(new Size((int)WeaponIconSize.X, (int)WeaponIconSize.Y)));

            return ImageResource.FromStream(asset.AsStream());
        }
    }
}
