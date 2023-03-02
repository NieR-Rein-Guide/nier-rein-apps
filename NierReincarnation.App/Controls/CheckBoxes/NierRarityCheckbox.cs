using ImGui.Forms.Resources;
using NierReincarnation.App.Resources;
using NierReincarnation.Core.Dark.Generated.Type;
using System;
using System.Numerics;
using Veldrid;

namespace NierReincarnation.App.Controls.CheckBoxes
{
    internal class NierRarityCheckbox : NierIconCheckbox
    {
        private const int StarPadding_ = 3;

        public RarityType RarityType { get; set; }

        protected override Vector2 GetIconSize()
        {
            var starCount = GetStarCount();
            return new Vector2((starCount * NierResources.RarityStarSize.X) + ((starCount - 1) * StarPadding_), NierResources.RarityStarSize.Y);
        }

        protected override void DrawIcon(Rectangle contentRect)
        {
            var pos = contentRect.Position + GetIconPosition();
            DrawRarityStars(NierResources.LoadRarityStarIcon(RarityType), pos, GetStarCount());
        }

        private int GetStarCount()
        {
            return (int)RarityType / 10;
        }

        private static void DrawRarityStars(ImageResource starIcon, Vector2 pos, int count)
        {
            for (var i = 0; i < count; i++)
            {
                ImGuiNET.ImGui.GetWindowDrawList().AddImage((IntPtr)starIcon, pos, pos + NierResources.RarityStarSize);
                pos += new Vector2(NierResources.RarityStarSize.X + StarPadding_, 0);
            }
        }
    }
}
