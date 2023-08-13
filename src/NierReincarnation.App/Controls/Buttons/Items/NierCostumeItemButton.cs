using ImGui.Forms.Resources;
using ImGuiNET;
using NierReincarnation.App.Resources;
using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Dark.Generated.Type;
using System.Collections.Generic;
using System.Numerics;
using Veldrid;

namespace NierReincarnation.App.Controls.Buttons.Items
{
    internal class NierCostumeItemButton : NierItemButton
    {
        private static FontResource AwakenFont => Resources.FontResources.FotRodin(13);

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

            if (Costume?.AwakenCount > 0)
            {
                result.Add(Costume.AwakenCount < 5
                    ? NierResources.LoadAwakenDefaultIcon()
                    : NierResources.LoadAwakenFullIcon());
            }

            return result.ToArray();
        }

        protected override void UpdateIcon(int iconIndex, Rectangle iconRect)
        {
            if (iconIndex != 1)
                return;

            if (AwakenFont != null)
                ImGuiNET.ImGui.PushFont((ImFontPtr)AwakenFont);

            var text = $"{Costume.AwakenCount}";
            var textWidth = FontResource.GetCurrentLineWidth(text, AwakenFont);
            var textHeight = FontResource.GetCurrentLineHeight(AwakenFont);

            var textPos = iconRect.Position + new Vector2((iconRect.Width - textWidth) / 2f, (iconRect.Height - textHeight) / 2f);
            ImGuiNET.ImGui.GetWindowDrawList().AddText(textPos, ImGuiNET.ImGui.GetColorU32(ImGuiCol.Text), text);

            if (AwakenFont != null)
                ImGuiNET.ImGui.PopFont();
        }
    }
}
