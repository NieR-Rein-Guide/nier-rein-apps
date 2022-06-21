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
    class NierAttributeCheckbox : NierIconCheckbox
    {
        private static ImageResource FireIconResource;
        private static ImageResource WaterIconResource;
        private static ImageResource WindIconResource;
        private static ImageResource LightIconResource;
        private static ImageResource DarkIconResource;

        private static readonly Vector2 AttributeIconSize = new Vector2(20, 20);

        public AttributeType Attribute { get; set; }

        protected override Vector2 GetIconSize()
        {
            return AttributeIconSize;
        }

        protected override void DrawIcon(Rectangle contentRect)
        {
            var pos = contentRect.Position + GetIconPosition();
            switch (Attribute)
            {
                case AttributeType.FIRE:
                    if (FireIconResource == null)
                        FireIconResource = LoadIcon(NierResources.LoadAttributeIcon(Attribute));

                    ImGuiNET.ImGui.GetWindowDrawList().AddImage((IntPtr)FireIconResource, pos, pos + AttributeIconSize);
                    break;

                case AttributeType.WATER:
                    if (WaterIconResource == null)
                        WaterIconResource = LoadIcon(NierResources.LoadAttributeIcon(Attribute));

                    ImGuiNET.ImGui.GetWindowDrawList().AddImage((IntPtr)WaterIconResource, pos, pos + AttributeIconSize);
                    break;

                case AttributeType.WIND:
                    if (WindIconResource == null)
                        WindIconResource = LoadIcon(NierResources.LoadAttributeIcon(Attribute));

                    ImGuiNET.ImGui.GetWindowDrawList().AddImage((IntPtr)WindIconResource, pos, pos + AttributeIconSize);
                    break;

                case AttributeType.LIGHT:
                    if (LightIconResource == null)
                        LightIconResource = LoadIcon(NierResources.LoadAttributeIcon(Attribute));

                    ImGuiNET.ImGui.GetWindowDrawList().AddImage((IntPtr)LightIconResource, pos, pos + AttributeIconSize);
                    break;

                case AttributeType.DARK:
                    if (DarkIconResource == null)
                        DarkIconResource = LoadIcon(NierResources.LoadAttributeIcon(Attribute));

                    ImGuiNET.ImGui.GetWindowDrawList().AddImage((IntPtr)DarkIconResource, pos, pos + AttributeIconSize);
                    break;
            }
        }

        private ImageResource LoadIcon(ImageAsset asset)
        {
            asset.Image.Mutate(x => x.Resize(new Size((int)AttributeIconSize.X, (int)AttributeIconSize.Y)));

            return ImageResource.FromStream(asset.AsStream());
        }
    }
}
