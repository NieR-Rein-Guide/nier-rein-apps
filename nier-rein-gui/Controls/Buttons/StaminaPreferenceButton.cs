using System.Drawing;
using System.Numerics;
using ImGui.Forms.Controls.Base;
using ImGui.Forms.Extensions;
using ImGuiNET;
using nier_rein_gui.Dialogs;
using Rectangle = Veldrid.Rectangle;
using Size = ImGui.Forms.Models.Size;

namespace nier_rein_gui.Controls.Buttons
{
    class StaminaPreferenceButton : Component
    {
        private static readonly Vector2 ButtonSize = new Vector2(16, 16);
        private static readonly Vector2 BorderSize = new Vector2(14, 14);
        private static readonly Vector2 IconSize = new Vector2(10, 10);

        private static readonly uint BorderColor = Color.FromArgb(0x6B, 0x63, 0x60).ToUInt32();
        private static readonly uint BorderActiveColor = Color.FromArgb(0x74, 0x71, 0x6C).ToUInt32();

        public override Size GetSize()
        {
            return new Size((int)ButtonSize.X, (int)ButtonSize.Y);
        }

        protected override async void UpdateInternal(Rectangle contentRect)
        {
            var isClicked = ImGuiNET.ImGui.Button(string.Empty, ButtonSize);

            // Draw border
            var borderPos = contentRect.Position + new Vector2(1, 1);
            var borderColor = ImGuiNET.ImGui.IsItemActive() ? BorderActiveColor : BorderColor;
            ImGuiNET.ImGui.GetWindowDrawList().AddRect(borderPos, borderPos + BorderSize, borderColor, 0, ImDrawFlags.None, 1);

            // Draw plus
            var plusPos = contentRect.Position + new Vector2((int)ButtonSize.X / 2, (int)(ButtonSize.Y - IconSize.Y) / 2)-new Vector2(1,0);
            var plusPos2 = contentRect.Position + new Vector2((int)(ButtonSize.X - IconSize.X) / 2, (int)ButtonSize.Y / 2)-new Vector2(0,0);
            ImGuiNET.ImGui.GetWindowDrawList().AddLine(plusPos, plusPos + new Vector2(0, IconSize.Y), borderColor, 2);
            ImGuiNET.ImGui.GetWindowDrawList().AddLine(plusPos2, plusPos2 + new Vector2(IconSize.X, 0), borderColor, 2);

            if (isClicked)
                await new StaminaPreferenceDialog().ShowAsync();
        }
    }
}
