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
    class NierRarityCheckbox : NierIconCheckbox
    {
        private const int StarPadding_ = 3;

        private static ImageResource NormalIconResource;
        private static ImageResource RareIconResource;
        private static ImageResource SrIconResource;
        private static ImageResource LegendIconResource;

        private static readonly Vector2 SingleStarSize = new Vector2(15, 15);

        public RarityType RarityType { get; set; }

        protected override Vector2 GetIconSize()
        {
            var starCount = (int)RarityType / 10;
            return new Vector2(starCount * SingleStarSize.X + (starCount - 1) * StarPadding_, SingleStarSize.Y);
        }

        protected override void DrawIcon(Rectangle contentRect)
        {
            var pos = contentRect.Position + GetIconPosition();
            switch (RarityType)
            {
                case RarityType.RARE:
                    if (RareIconResource == null)
                        RareIconResource = LoadIcon(NierResources.LoadRarityStarIcon(RarityType));

                    DrawRarityStars(RareIconResource, pos, 2);
                    break;

                case RarityType.S_RARE:
                    if (SrIconResource == null)
                        SrIconResource = LoadIcon(NierResources.LoadRarityStarIcon(RarityType));

                    DrawRarityStars(SrIconResource, pos, 3);
                    break;

                case RarityType.SS_RARE:
                    if (LegendIconResource == null)
                        LegendIconResource = LoadIcon(NierResources.LoadRarityStarIcon(RarityType));

                    DrawRarityStars(LegendIconResource, pos, 4);
                    break;

                case RarityType.LEGEND:
                    if (LegendIconResource == null)
                        LegendIconResource = LoadIcon(NierResources.LoadRarityStarIcon(RarityType));

                    DrawRarityStars(LegendIconResource, pos, 5);
                    break;
            }
        }

        private void DrawRarityStars(ImageResource starIcon, Vector2 pos, int count)
        {
            for (var i = 0; i < count; i++)
            {
                ImGuiNET.ImGui.GetWindowDrawList().AddImage((IntPtr)starIcon, pos, pos + SingleStarSize);
                pos += new Vector2(SingleStarSize.X + StarPadding_, 0);
            }
        }

        private ImageResource LoadIcon(ImageAsset asset)
        {
            asset.Image.Mutate(x => x.Resize(new Size((int)SingleStarSize.X, (int)SingleStarSize.Y)));

            return ImageResource.FromStream(asset.AsStream());
        }
    }
}
